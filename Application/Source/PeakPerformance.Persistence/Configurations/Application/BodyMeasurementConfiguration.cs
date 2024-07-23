using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeakPerformance.Common;
using PeakPerformance.Domain.Entities.Application;

namespace PeakPerformance.Persistence.Configurations.Application;

internal class BodyMeasurementConfiguration : IEntityTypeConfiguration<BodyMeasurement>
{
    public void Configure(EntityTypeBuilder<BodyMeasurement> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.Waist)
            .HasColumnType(Constants.MeasurementDecimalType);

        builder.Property(_ => _.Hips)
           .HasColumnType(Constants.MeasurementDecimalType);

        builder.Property(_ => _.Neck)
           .HasColumnType(Constants.MeasurementDecimalType);

        builder.Property(_ => _.Chest)
           .HasColumnType(Constants.MeasurementDecimalType);

        builder.Property(_ => _.Shoulders)
           .HasColumnType(Constants.MeasurementDecimalType);

        builder.Property(_ => _.RightBiceps)
           .HasColumnType(Constants.MeasurementDecimalType);

        builder.Property(_ => _.LeftBiceps)
           .HasColumnType(Constants.MeasurementDecimalType);

        builder.Property(_ => _.RightForearm)
           .HasColumnType(Constants.MeasurementDecimalType);

        builder.Property(_ => _.LeftForearm)
           .HasColumnType(Constants.MeasurementDecimalType);

        builder.Property(_ => _.RightThigh)
           .HasColumnType(Constants.MeasurementDecimalType);

        builder.Property(_ => _.LeftThigh)
           .HasColumnType(Constants.MeasurementDecimalType);

        builder.Property(_ => _.RightCalf)
           .HasColumnType(Constants.MeasurementDecimalType);

        builder.Property(_ => _.LeftCalf)
           .HasColumnType(Constants.MeasurementDecimalType);

        // Relationships

        builder.HasOne(_ => _.User)
            .WithMany(u => u.BodyMeasurements)
            .HasForeignKey(_ => _.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(_ => _.MeasurementUnit)
            .WithMany(mu => mu.BodyMeasurements)
            .HasForeignKey(_ => _.MeasurementUnitId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}