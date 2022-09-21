using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.OpenApi.Models;
using Wims.Api.Common.Errors;
using Wims.Api.Common.Mapping;

namespace Wims.Api
{
    public static class DependencyInjectionApi
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddMappings();

            services.AddControllers();

            services.AddSingleton<ProblemDetailsFactory, WimsProblemDetailsFactory>();

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Wims API",
                    Version = "v1",
                });
            });
            return services;
        }
    }
}
