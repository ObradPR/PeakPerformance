using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeakPerformance.Domain.Entities.Application;

namespace PeakPerformance.Persistence.Configurations.Application;

internal class UserActivityLogConfiguration : IEntityTypeConfiguration<UserActivityLog>
{
    public void Configure(EntityTypeBuilder<UserActivityLog> builder)
    {
        builder.HasKey(_ => _.Id);

        // relationships

        builder.HasOne(_ => _.User)
            .WithMany(u => u.UserActivityLogs)
            .HasForeignKey(_ => _.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(_ => _.ActionType)
            .WithMany(at => at.UserActivityLogs)
            .HasForeignKey(_ => _.ActionTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}