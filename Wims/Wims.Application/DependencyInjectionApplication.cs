using Microsoft.Extensions.DependencyInjection;
using Wims.Application.Services.Authentication.Commands;
using Wims.Application.Services.Authentication.Queries;

namespace Wims.Application
{
    public static class DependencyInjectionApplication
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
            services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();

            return services;
        }
    }
}
