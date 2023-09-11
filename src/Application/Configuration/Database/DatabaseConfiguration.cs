using Microsoft.EntityFrameworkCore;

namespace Xp.Api.Application.Configuration.Database;

public static class DatabaseConfiguration
{
    public static void MigrationInitialization(this IServiceCollection services)
    {
        using ServiceProvider serviceProvider = services.BuildServiceProvider();
        DatabaseContext context = serviceProvider.GetRequiredService<DatabaseContext>();
        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }
    }
}