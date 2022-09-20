using Wims.Domain.Entities;

namespace Wims.Application.Services.Authentication.Common
{
    public record AuthenticationResult(
        User User,
        string Token);
}
