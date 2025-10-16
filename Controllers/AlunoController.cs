using FitTrackAPI.DTOs;
using FitTrackAPI.Exceptions;
using FitTrackAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitTrackAPI.Controllers
{
    [ApiController]
    [Route("api/alunos")]
    public class AlunoController : ControllerBase
    {
        private readonly AlunoService _service;

        public AlunoController(AlunoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var alunos = await _service.ListarAlunos();
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var aluno = await _service.BuscarAlunoById(id);
            return Ok(aluno);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] AlunoDTO aluno)
        {
            try
            {
                var novoAluno = await _service.CadastrarAluno(aluno.Nome, aluno.Email);

                var response = new
                {
                    message = "Aluno cadastrado com sucesso",
                    data = novoAluno
                };

                return CreatedAtAction(nameof(GetById), new { id = novoAluno.Id }, response);
            }
            catch (ValidationException ex)
            {
                // Erro de regra de negócio previsível → 400
                return BadRequest(new { message = ex.Message });
            }
            catch (NotFoundException ex)
            {
                // Caso algum recurso relacionado não exista → 404
                return NotFound(new { message = ex.Message });
            }
            catch (DomainException ex)
            {
                // Qualquer outro erro de domínio → 422 (Unprocessable Entity)
                return StatusCode(422, new { message = ex.Message });
            }
            catch (Exception ex)
            {
                // Erro inesperado → 500
                return StatusCode(500, new { message = "Erro interno no servidor.", details = ex.Message });
            }
        }
    }
}
