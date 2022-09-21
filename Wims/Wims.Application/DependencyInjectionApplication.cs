using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace Wims.Application
{
    public static class DependencyInjectionApplication
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DependencyInjectionApplication).Assembly);

            return services;
        }
    }
}
