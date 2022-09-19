using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.OpenApi.Models;
using Wims.Api.Errors;
using Wims.Api.Filters;
using Wims.Api.Middleware;
using Wims.Application;
using Wims.Infrastructure;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        {
            builder.Services
                .AddApplication()
                .AddInfrastructure(builder.Configuration);

            //Method 2 Error Handling
            //builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
            builder.Services.AddControllers();

            //builder.Services.AddSingleton<ProblemDetailsFactory, WimsProblemDetailsFactory>();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Wims API",
                    Version = "v1",
                });
            });
        }

        var app = builder.Build();
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Wims API V1");
                });
            }

            //Method 1 Error Handling
            //app.UseMiddleware<ErrorHandlingMiddleware>();

            //Method 3 Error Handling
            app.UseExceptionHandler("/error");
            
            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.MapControllers();

            app.Run();
        }
    }
}