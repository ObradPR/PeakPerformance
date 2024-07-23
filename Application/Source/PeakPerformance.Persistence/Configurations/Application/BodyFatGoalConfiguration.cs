using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeakPerformance.Common;
using PeakPerformance.Domain.Entities.Application;

namespace PeakPerformance.Persistence.Configurations.Application;

internal class BodyFatGoalConfiguration : IEntityTypeConfiguration<BodyFatGoal>
{
    public void Configure(EntityTypeBuilder<BodyFatGoal> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.TargetBodyFatPercentage)
            .IsRequired()
            .HasColumnType(Constants.MeasurementDecimalType);

        // Relationships

        builder.HasOne(_ => _.User)
            .WithMany(u => u.BodyFatGoals)
            .HasForeignKey(_ => _.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}