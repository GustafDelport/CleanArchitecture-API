using Microsoft.AspNetCore.Mvc;
using Wims.Application.Services.Authentication;
using Wims.Contracts.Authentication;
using FluentResults;
using Wims.Application.Common.Errors;

namespace Wims.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {

        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            Result<AuthenticationResult> registerResult = _authenticationService.Register(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password);

            if (registerResult.IsSuccess)
            {
                return Ok(MapAuthResult(registerResult.Value));
            }

            var firstError = registerResult.Errors[0];

            if (firstError is DuplicateEmailError)
            {
                return Problem(statusCode: StatusCodes.Status409Conflict, detail: firstError.Message);
            }

            return Problem();
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            Result<AuthenticationResult> loginResult = _authenticationService.Login(
                request.Email,
                request.Password);


            if (loginResult.IsSuccess)
            {
                return Ok(MapAuthResult(loginResult.Value));
            }

            foreach (var item in loginResult.Errors)
            {
                switch (item)
                {
                    case EmailNotFoundError: return Problem(statusCode: StatusCodes.Status404NotFound, detail: item.Message);
                    case IncorrectPasswordError: return Problem(statusCode: StatusCodes.Status401Unauthorized, detail: item.Message);
                }
            }

            return Problem();
        }

        private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
        {
            return new AuthenticationResponse(
                            authResult.User.Id,
                            authResult.User.FirstName,
                            authResult.User.LastName,
                            authResult.User.Email,
                            authResult.Token);
        }
    }
}
