using ErrorOr;
using MediatR;
using Wims.Application.Authentication.Commands.Register;
using Wims.Application.Authentication.Common;

namespace Wims.Application.Common.Behaviors
{
    public class ValidationRegisterCommandBehavior : IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        public async Task<ErrorOr<AuthenticationResult>> Handle(
            RegisterCommand request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<ErrorOr<AuthenticationResult>> next)
        {
            var result = await next();

            return result;
        }
    }
}
