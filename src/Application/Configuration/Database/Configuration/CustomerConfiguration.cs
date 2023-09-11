using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Xp.Api.Application.Domain;

namespace Xp.Api.Application.Configuration.Database.Configuration;

public sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder
            .HasKey(p => p.Id);

        builder
            .HasOne(p => p.Address);

        builder
            .Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder
            .Property(p => p.FullName)
            .HasDefaultValue(false)
            .IsRequired();

        builder
            .Property(p => p.Telephone)
            .HasDefaultValue(false)
            .IsRequired();

        builder
            .Property(p => p.Email)
            .HasDefaultValue(false)
            .IsRequired();

        builder
            .HasOne(p => p.Address)
            .WithOne()
            .HasForeignKey<Customer>(c => c.AddressId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Navigation(p => p.Address)
            .AutoInclude();
    }
}