using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeakPerformance.Common;
using PeakPerformance.Domain.Entities.Application;

namespace PeakPerformance.Persistence.Configurations.Application;

internal class WeightGoalConfiguration : IEntityTypeConfiguration<WeightGoal>
{
    public void Configure(EntityTypeBuilder<WeightGoal> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.TargetWeight)
            .IsRequired()
            .HasColumnType(Constants.MeasurementDecimalType);

        // Relationships

        builder.HasOne(_ => _.User)
            .WithMany(u => u.WeightsGoals)
            .HasForeignKey(_ => _.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}