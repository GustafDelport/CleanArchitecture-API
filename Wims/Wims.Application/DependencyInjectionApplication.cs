using Microsoft.Extensions.DependencyInjection;
using Wims.Application.Services.Authentication;

namespace Wims.Application
{
    public static class DependencyInjectionApplication
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            return services;
        }
    }
}
