using FitTrackAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitTrackAPI.Controllers
{
    [ApiController]
    [Route("api/execucaoexercicio")]
    public class ExecucaoExercicioController : BaseController
    {
        private ExecucaoExercicioService _service;

        public ExecucaoExercicioController(ExecucaoExercicioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ListarExecucoesExercicio()
        {
            var execucoes = await _service.ListarExecucoesExercicio();
            return Ok(execucoes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarExecucaoExercicioPorId(Guid id)
        {
            var execucao = await _service.BuscarExecucaoExercicioPorId(id);
            return Ok(execucao);
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarExecucaoExercicio([FromBody] DTOs.ExecucaoExercicioRegisterDTO data)
        {
            try
            {
                var novaExecucao = await _service.RegistrarExecucaoExercicio(data);
                return CreatedAtAction(nameof(BuscarExecucaoExercicioPorId), new { id = novaExecucao.Id }, novaExecucao);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarExecucaoExercicio(Guid id)
        {
            try
            {
                await _service.DeletarExecucaoExercicio(id);

                var response = new
                {
                    message = "Execução de exercício deletada com sucesso!"
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
