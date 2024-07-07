using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeakPerformance.Domain.Entities.Application;
using PeakPerformance.Persistence.Configurations._Base;
using PeakPerformance.Persistence.Extensions;

namespace PeakPerformance.Persistence.Configurations.Application;

internal class UserRoleConfiguration : EntityConfiguration<UserRole>
{
    protected override void ConfigureEntity(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasIndex(_ => new { _.UserId, _.RoleId })
            .IsUnique()
            .HasFilter(nameof(UserRole.UserId).GetNullFilterForProperty<UserRole>());

        // Relationships

        builder.HasOne(_ => _.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(_ => _.RoleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(_ => _.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(_ => _.UserId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}