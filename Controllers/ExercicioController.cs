using FitTrackAPI.DTOs;
using FitTrackAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace FitTrackAPI.Controllers
{
    [ApiController]
    [Route("api/exercicios")]
    public class ExercicioController : BaseController
    {
        private ExercicioService service;

        public ExercicioController(ExercicioService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var exercicios = await service.ListarTodosExercicios();
            return Ok(exercicios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var exercicio = await service.ObterExercicioPorId(id);
            return Ok(exercicio);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] ExercicioRegisterDTO data)
        {
            try
            {
                var novoExercicio = await service.RegistrarExercicio(data);

                var response  = new
                {
                    message = "Exercicio cadastrado com sucesso!",
                    data = novoExercicio
                };

                return Ok(response);
            }
            catch(Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ExercicioUpdateDTO data)
        {
            try
            {
                var updatedExercicio = await service.AtualizarExercicio(id, data);

                var response = new
                {
                    message = "Exercício atualizado com sucesso!",
                    data = updatedExercicio
                };

                return Ok(response);
            }
            catch(Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await service.DeletarExercicio(id);

                var response = new
                {
                    message = "Exercício deletado com sucesso!"
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
