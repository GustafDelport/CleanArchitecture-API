using Wims.Domain.Entities;

namespace Wims.Application.Authentication.Common
{
    public record AuthenticationResult(
        User User,
        string Token);
}