using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Wims.Application.Common.Errors;

namespace Wims.Api.Controllers
{
    public class ErrorsController : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("/error")]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            var (statusCode, message) = exception switch
            {
                IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
                _ => (StatusCodes.Status500InternalServerError, "An unexpected error occured.")
            };

            return Problem(statusCode: statusCode, title: message);
            
        }
    }
}
