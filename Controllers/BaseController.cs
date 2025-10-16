using FitTrackAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace FitTrackAPI.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult HandleException(Exception ex)
        {
            return ex switch
            {
                ValidationException => BadRequest(new { message = ex.Message }),
                NotFoundException => NotFound(new { message = ex.Message }),
                DomainException => StatusCode(422, new { message = ex.Message }),
                _ => StatusCode(500, new { message = "Erro interno no servidor.", details = ex.Message })
            };
        }
    }
}
