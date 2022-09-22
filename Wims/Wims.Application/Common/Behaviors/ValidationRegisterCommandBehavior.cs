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
            //Runs before Command is handled
            var result = await next();

            //Runs after the command is handled


            //Returns
            return result;
        }
    }
}
