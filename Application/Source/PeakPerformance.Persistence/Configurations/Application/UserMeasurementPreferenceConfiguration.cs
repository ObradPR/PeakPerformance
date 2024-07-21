using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeakPerformance.Domain.Entities.Application;
using PeakPerformance.Persistence.Configurations._Base;
using PeakPerformance.Persistence.Extensions;

namespace PeakPerformance.Persistence.Configurations.Application;

internal class UserMeasurementPreferenceConfiguration : EntityConfiguration<UserMeasurementPreference>
{
    protected override void ConfigureEntity(EntityTypeBuilder<UserMeasurementPreference> builder)
    {
        builder.ToTable(_ => _.HasTrigger(Extensions.Extensions.GetAuditTriggerName<UserMeasurementPreference>()));

        builder.HasIndex(_ => new { _.UserId, _.WeightUnitId, _.MeasurementUnitId })
            .IsUnique()
            .HasFilter(nameof(UserMeasurementPreference.UserId).GetNullFilterForProperty<UserMeasurementPreference>());

        // Relationships

        builder.HasOne(_ => _.User)
            .WithMany(u => u.UserMeasurementPreferences)
            .HasForeignKey(_ => _.UserId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(_ => _.WeightUnit)
            .WithMany(mu => mu.WeightUnitPreferences)
            .HasForeignKey(_ => _.WeightUnitId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(_ => _.MeasurementUnit)
            .WithMany(mu => mu.MeasurementUnitPreferences)
            .HasForeignKey(_ => _.MeasurementUnitId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}