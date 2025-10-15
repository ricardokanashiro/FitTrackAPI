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
    }
}
