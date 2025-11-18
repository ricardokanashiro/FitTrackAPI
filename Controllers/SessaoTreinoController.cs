using FitTrackAPI.DTOs;
using FitTrackAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitTrackAPI.Controllers
{
    [ApiController]
    [Route("api/sessaotreino")]
    public class SessaoTreinoController : BaseController
    {
        private SessaoTreinoService _service;

        public SessaoTreinoController(SessaoTreinoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ListarSessoes()
        {
            var sessoes = await _service.ListarSessoesTreino();
            return Ok(sessoes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarSessaoPorId(Guid id)
        {
            try
            {
                var sessao = await _service.BuscarSessaoTreinoPorId(id);
                return Ok(sessao);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarSessao([FromBody] SessaoTreinoRegisterDTO data)
        {
            try
            {
                var novaSessao = await _service.RegistrarSessaoTreino(data);

                var response = new
                {
                    message = "Sessão de treino registrada com sucesso",
                    data = novaSessao
                };

                return CreatedAtAction(nameof(BuscarSessaoPorId), new { id = novaSessao.Id }, response);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarSessao(Guid id, [FromBody] SessaoTreinoUpdateDTO data)
        {
            try
            {
                var updatedSessao = await _service.AtualizarSessaoTreino(id, data);

                var response = new
                {
                    message = "Sessão de treino atualizada com sucesso",
                    data = updatedSessao
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
                await _service.DeletarSessaoTreino(id);

                var response = new
                {
                    message = "Treino deletado com sucesso!"
                };

                return Ok(response);
            }
            catch(Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}
