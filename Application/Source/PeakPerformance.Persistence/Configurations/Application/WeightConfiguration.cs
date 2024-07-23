using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeakPerformance.Common;
using PeakPerformance.Domain.Entities.Application;

namespace PeakPerformance.Persistence.Configurations.Application;

internal class WeightConfiguration : IEntityTypeConfiguration<Weight>
{
    public void Configure(EntityTypeBuilder<Weight> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.Value)
            .HasColumnType(Constants.MeasurementDecimalType)
            .IsRequired();

        builder.Property(_ => _.BodyFatPercentage)
            .HasColumnType(Constants.MeasurementDecimalType);

        // Relationships

        builder.HasOne(_ => _.User)
            .WithMany(u => u.Weights)
            .HasForeignKey(_ => _.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(_ => _.WeightUnit)
            .WithMany(mu => mu.Weights)
            .HasForeignKey(_ => _.WeightUnitId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}