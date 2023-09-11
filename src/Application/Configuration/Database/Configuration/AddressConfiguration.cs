using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Xp.Api.Application.Domain;

namespace Xp.Api.Application.Configuration.Database.Configuration;

public sealed class CalculationConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder
            .HasKey(a => a.Id);

        builder
            .Property(a => a.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(a => a.AddressLine)
            .HasDefaultValue(false)
            .IsRequired();

        builder
            .Property(a => a.Neighborhood)
            .HasDefaultValue(false)
            .IsRequired();

        builder
            .Property(a => a.ZipCode)
            .HasDefaultValue(false)
            .IsRequired();

        builder
            .Property(a => a.City)
            .HasDefaultValue(false)
            .IsRequired();

        builder
            .Property(a => a.State)
            .HasDefaultValue(false)
            .IsRequired();
    }
}
