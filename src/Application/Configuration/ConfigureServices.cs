using Microsoft.EntityFrameworkCore;
using Xp.Api.Application.Configuration.Database;
using Xp.Api.Application.Configuration.Database.Repositories;
using Xp.Api.Application.Services;

namespace Xp.Api.Application.Configuration;

public static class ConfigureServices
{
    public static void ConfigApplication(this IServiceCollection services, IConfiguration config)
    {
        string connectionString = config.GetConnectionString("DefaultConnection");
        services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
    }
}