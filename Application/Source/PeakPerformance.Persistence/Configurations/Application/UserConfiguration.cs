using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeakPerformance.Domain.Entities.Application;
using PeakPerformance.Persistence.Configurations._Base;

namespace PeakPerformance.Persistence.Configurations.Application;

internal class UserConfiguration : EntityConfiguration<User>
{
    protected override void ConfigureEntity(EntityTypeBuilder<User> builder)
    {
        builder.Property(_ => _.FirstName)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(_ => _.MiddleName)
            .HasMaxLength(20);

        builder.Property(_ => _.LastName)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(_ => _.Username)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(_ => _.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(_ => _.Password)
            .IsRequired();

        builder.Property(_ => _.DateOfBirth)
            .IsRequired();

        builder.Property(_ => _.PhoneNumber)
            .IsRequired()
            .HasMaxLength(15);

        // Indexes

        builder.HasIndex(_ => _.Email)
            .IsUnique();

        builder.HasIndex(_ => _.Username)
            .IsUnique();

        builder.HasIndex(_ => new
        {
            _.FirstName,
            _.MiddleName,
            _.LastName,
        }).IncludeProperties(_ => _.DateOfBirth);
    }
}