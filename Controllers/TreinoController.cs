using FitTrackAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace FitTrackAPI.Controllers
{
    [ApiController]
    [Route("/api/treinos")]
    public class TreinoController : BaseController
    {
        private TreinoService _service;

        public TreinoController(TreinoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTreinos()
        {
            var alunos = await _service.ListarTreinos();
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTreinoById(Guid id)
        {
            try
            {
                var aluno = await _service.BuscarTreinoById(id);
                return Ok(aluno);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> RegisterTreino([FromBody] TreinoRegisterDTO body)
        {
            try
            {
                var createdTreino = await _service.CadastrarTreino(body.AlunoId, body.Titulo);

                var response = new
                {
                    message = "Treino cadastrado com sucesso!",
                    data = createdTreino
                };

                return CreatedAtAction(nameof(GetTreinoById), new { id = createdTreino.Id }, response);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTreino(Guid id, [FromBody] TreinoUpdateDTO body)
        {
            try
            {
                var updatedTreino = await _service.AtualizarTreino(id, body.titulo);

                var response = new
                {
                    message = "Treino atualizado com sucesso!",
                    data = updatedTreino
                };

                return Ok(updatedTreino);
            }
            catch(Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTreino(Guid id)
        {
            try
            {
                await _service.DeletarTreino(id);

                var message = new
                {
                    message = "Treino deletado com sucesso!"
                };

                return Ok(message);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}
