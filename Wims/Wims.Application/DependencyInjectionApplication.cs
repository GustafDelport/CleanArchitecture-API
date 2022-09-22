using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Wims.Application.Authentication.Commands.Register;
using ErrorOr;
using Wims.Application.Authentication.Common;
using Wims.Application.Common.Behaviors;
using FluentValidation;
using System.Reflection;

namespace Wims.Application
{
    public static class DependencyInjectionApplication
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DependencyInjectionApplication).Assembly);

            services.AddScoped(
                typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
