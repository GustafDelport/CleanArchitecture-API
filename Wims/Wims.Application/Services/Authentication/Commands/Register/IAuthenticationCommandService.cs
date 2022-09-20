using ErrorOr;
using Wims.Application.Services.Authentication.Common;

namespace Wims.Application.Services.Authentication.Commands.Register
{
    public interface IAuthenticationCommandService
    {
        ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
    }
}
