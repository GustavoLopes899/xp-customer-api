using Microsoft.OpenApi.Models;
using Xp.Api.Application.Configuration;
using Xp.Api.Application.Configuration.Database;
using Xp.Api.Application.Endpoints;

namespace Xp.Api.Application;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        IConfiguration config = builder.Configuration;
        builder.Services.ConfigApplication(config);
        builder.Services.MigrationInitialization();
        builder.Services.AddAuthorization();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.EnableAnnotations();
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "Customers Xp Api Application", Version = "v1" });
        });

        WebApplication app = builder.Build();
        app.UseAuthorization();
        CustomerEndpointConfig.AddEndpoints(app);
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Customers Xp Api Application V1");
            });
        }
        app.Run();
    }
}