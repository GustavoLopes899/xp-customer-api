using Microsoft.EntityFrameworkCore;
using Xp.Api.Application.Domain;

namespace Xp.Api.Application.Configuration.Database;

public class DatabaseContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        ChangeTracker.LazyLoadingEnabled = false;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (modelBuilder is null)
        {
            throw new ArgumentNullException(nameof(modelBuilder));
        }

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
    }
}