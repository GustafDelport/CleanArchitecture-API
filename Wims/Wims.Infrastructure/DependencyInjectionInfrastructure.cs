using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wims.Application.Common.Interfaces.Authentication;
using Wims.Application.Common.Interfaces.Persistance;
using Wims.Application.Common.Interfaces.Services;
using Wims.Infrastructure.Authentication;
using Wims.Infrastructure.Persistance;
using Wims.Infrastructure.Services;

namespace Wims.Infrastructure
{
    public static class DependencyInjectionInfrastructure
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                                                           ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
