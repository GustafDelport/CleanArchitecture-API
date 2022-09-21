using Microsoft.AspNetCore.Mvc;
using Wims.Contracts.Authentication;
using ErrorOr;
using MediatR;
using Wims.Application.Authentication.Commands.Register;
using Wims.Application.Authentication.Common;
using Wims.Application.Authentication.Queries.Login;

namespace Wims.Api.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _mediator;

        public AuthenticationController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);

            ErrorOr<AuthenticationResult> registerResult = await _mediator.Send(command);

            return registerResult.Match(
                registerResult => Ok(MapAuthResult(registerResult)),
                errors => Problem(errors));

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = new LoginQuery(request.Email, request.Password);

            ErrorOr<AuthenticationResult> loginResult = await _mediator.Send(query);

            return loginResult.Match(
                loginResult => Ok(MapAuthResult(loginResult)),
                errors => Problem(errors));
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
