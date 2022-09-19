using Wims.Domain.Entities;

namespace Wims.Application.Services.Authentication
{
    public record AuthenticationResult(
        User User,
        string Token);
}
