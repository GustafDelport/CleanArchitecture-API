using Wims.Api;
using Wims.Application;
using Wims.Infrastructure;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        {
            builder.Services
                .AddPresentation()
                .AddApplication()
                .AddInfrastructure(builder.Configuration);
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
            
            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.MapControllers();

            app.Run();
        }
    }
}