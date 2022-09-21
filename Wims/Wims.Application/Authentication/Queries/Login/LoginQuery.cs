using ErrorOr;
using MediatR;
using Wims.Application.Authentication.Common;

namespace Wims.Application.Authentication.Queries.Login
{
    public record LoginQuery(
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}

