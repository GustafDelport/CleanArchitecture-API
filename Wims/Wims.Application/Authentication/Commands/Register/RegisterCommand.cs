using ErrorOr;
using MediatR;
using Wims.Application.Authentication.Common;

namespace Wims.Application.Authentication.Commands.Register
{
    public record RegisterCommand (
        string FirstName,
        string LastName,
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
