using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Wims.Application.Authentication.Commands.Register;
using ErrorOr;
using Wims.Application.Authentication.Common;
using Wims.Application.Common.Behaviors;

namespace Wims.Application
{
    public static class DependencyInjectionApplication
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DependencyInjectionApplication).Assembly);
            services.AddScoped<IPipelineBehavior<RegisterCommand,ErrorOr<AuthenticationResult>>,ValidationRegisterCommandBehavior>();

            return services;
        }
    }
}
