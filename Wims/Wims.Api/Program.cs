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

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();
        }

        var app = builder.Build();
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.MapControllers();

            app.Run();
        }
    }
}