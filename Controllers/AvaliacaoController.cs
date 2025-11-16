using FitTrackAPI.DTOs;
using FitTrackAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitTrackAPI.Controllers
{
    [ApiController]
    [Route("api/avaliacao")]
    public class AvaliacaoController : BaseController
    {
        private readonly AvaliacaoService _service;

        public AvaliacaoController(AvaliacaoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var avaliacoes = await _service.ListarAvaliacoes();

                var response = new
                {
                    message = "Avaliações listadas com sucesso!",
                    data = avaliacoes
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var avaliacao = await _service.BuscarAvaliacaoById(id);

                var response = new
                {
                    message = "Avaliação encontrada com sucesso!",
                    data = avaliacao
                };

                return Ok(response);
            }
            catch(Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] AvaliacaoDTO avaliacao)
        {
            try
            {
                var novaAvaliacao = await _service.RegistrarAvaliacao(avaliacao.AlunoId, avaliacao.Comentarios);

                var response = new
                {
                    message = "Avaliação registrada com sucesso!",
                    data = novaAvaliacao
                };

                return CreatedAtAction(nameof(GetById), new { id = novaAvaliacao.Id }, response);
            }
            catch(Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] AvaliacaoUpdateDTO body)
        {
            try
            {
                var avaliacao = await _service.AtualizarAvaliacao(id, body.comentarios);

                var response = new
                {
                    message = "Avaliação atualizada com sucesso!",
                    data = avaliacao
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
                await _service.DeletarAvaliacao(id);

                var response = new { message = "Avaliação deletada com sucesso!" };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}
