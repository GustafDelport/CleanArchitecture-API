using Microsoft.AspNetCore.Mvc;
using Wims.Contracts.Authentication;
using ErrorOr;
using MediatR;
using Wims.Application.Authentication.Commands.Register;
using Wims.Application.Authentication.Common;
using Wims.Application.Authentication.Queries.Login;
using MapsterMapper;

namespace Wims.Api.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);

            ErrorOr<AuthenticationResult> registerResult = await _mediator.Send(command);

            return registerResult.Match(
                registerResult => Ok(_mapper.Map<AuthenticationResponse>(registerResult)),
                errors => Problem(errors));

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);

            ErrorOr<AuthenticationResult> loginResult = await _mediator.Send(query);

            return loginResult.Match(
                loginResult => Ok(_mapper.Map<AuthenticationResponse>(loginResult)),
                errors => Problem(errors));
        }
    }
}
