using Microsoft.AspNetCore.Mvc;
using Wims.Application.Services.Authentication;
using Wims.Contracts.Authentication;
using ErrorOr;

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
           ErrorOr<AuthenticationResult> registerResult = _authenticationService.Register(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password);


            return registerResult.MatchFirst(
                registerResult => Ok(MapAuthResult(registerResult)),
                firstError => Problem(statusCode: StatusCodes.Status409Conflict, detail: firstError.Description));


        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            ErrorOr<AuthenticationResult> loginResult = _authenticationService.Login(
                request.Email,
                request.Password);


            return loginResult.MatchFirst(
                loginResult => Ok(MapAuthResult(loginResult)),
                firstError => Problem(statusCode: StatusCodes.Status409Conflict, detail: firstError.Description));
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
