namespace PeakPerformance.Domain.Entities.Application;

public class Weight : BaseAuditedDomain<long>, IConfigurableEntity
{
    public long UserId { get; set; }

    public decimal Value { get; set; }

    public eMeasurementUnit WeightUnitId { get; set; }

    public decimal? BodyFatPercentage { get; set; }

    [Column(TypeName = Constants.DB_TYPE_DATE)]
    public DateTime? LogDate { get; set; }

    //
    // Relationships
    //

    #region Relationships

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }

    [ForeignKey(nameof(WeightUnitId))]
    public virtual MeasurementUnit WeightUnit { get; set; }

    #endregion Relationships

    //
    // Configuration
    //

    public void Configure(ModelBuilder builder)
    {
        builder.Entity<Weight>(_ =>
        {
            _.Property(_ => _.Value).HasPrecision(5, 2).IsRequired();
            _.Property(_ => _.BodyFatPercentage).HasPrecision(4, 2);
        });
    }
}