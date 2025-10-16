using FitTrackAPI.DTOs;
using FitTrackAPI.Exceptions;
using FitTrackAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitTrackAPI.Controllers
{
    [ApiController]
    [Route("api/alunos")]
    public class AlunoController : BaseController
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
            try
            {
                var aluno = await _service.BuscarAlunoById(id);
                return Ok(aluno);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
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
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAlunoDTO aluno)
        {
            try
            {
                var alunoAtualizado = await _service.AtualizarAluno(id, aluno.Nome, aluno.Email, aluno.Ativo);

                var response = new
                {
                    message = "Aluno atualizado com sucesso",
                    data = alunoAtualizado
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _service.DeletarAluno(id);

                var response = new
                {
                    message = "Usuário deletado com sucesso!"
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}
