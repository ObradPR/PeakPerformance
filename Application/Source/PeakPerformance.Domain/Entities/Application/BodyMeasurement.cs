namespace PeakPerformance.Domain.Entities.Application;

public class BodyMeasurement : BaseAuditedDomain<long>, IConfigurableEntity
{
    public long UserId { get; set; }

    public decimal? Waist { get; set; }

    public decimal? Hips { get; set; }

    public decimal? Neck { get; set; }

    public decimal? Chest { get; set; }

    public decimal? Shoulders { get; set; }

    public decimal? RightBicep { get; set; }

    public decimal? LeftBicep { get; set; }

    public decimal? RightForearm { get; set; }

    public decimal? LeftForearm { get; set; }

    public decimal? RightThigh { get; set; }

    public decimal? LeftThigh { get; set; }

    public decimal? RightCalf { get; set; }

    public decimal? LeftCalf { get; set; }

    public eMeasurementUnit MeasurementUnitId { get; set; }

    //
    // Relationships
    //

    #region Relationships

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }

    [ForeignKey(nameof(MeasurementUnitId))]
    public virtual MeasurementUnit MeasurementUnit { get; set; }

    #endregion Relationships

    //
    // Configuration
    //

    public void Configure(ModelBuilder builder)
    {
        builder.Entity<BodyMeasurement>(_ =>
        {
            _.Property(_ => _.Waist).HasPrecision(5, 2);
            _.Property(_ => _.Hips).HasPrecision(5, 2);
            _.Property(_ => _.Neck).HasPrecision(5, 2);
            _.Property(_ => _.Chest).HasPrecision(5, 2);
            _.Property(_ => _.Shoulders).HasPrecision(5, 2);
            _.Property(_ => _.RightBicep).HasPrecision(5, 2);
            _.Property(_ => _.LeftBicep).HasPrecision(5, 2);
            _.Property(_ => _.RightForearm).HasPrecision(5, 2);
            _.Property(_ => _.LeftForearm).HasPrecision(5, 2);
            _.Property(_ => _.RightThigh).HasPrecision(5, 2);
            _.Property(_ => _.LeftThigh).HasPrecision(5, 2);
            _.Property(_ => _.RightCalf).HasPrecision(5, 2);
            _.Property(_ => _.LeftCalf).HasPrecision(5, 2);
        });
    }
}