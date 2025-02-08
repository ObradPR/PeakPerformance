namespace PeakPerformance.Domain.Entities.Application;

public class WeightGoal : BaseAuditedDomain<long>, IConfigurableEntity
{
    public long UserId { get; set; }

    public decimal TargetWeight { get; set; }

    public eMeasurementUnit WeightUnitId { get; set; }

    [Column(TypeName = Constants.DB_TYPE_DATE)]
    public DateTime StartDate { get; set; }

    [Column(TypeName = Constants.DB_TYPE_DATE)]
    public DateTime EndDate { get; set; }

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
        builder.Entity<WeightGoal>(_ =>
        {
            _.Property(_ => _.TargetWeight).HasPrecision(5, 2).IsRequired();
        });
    }
}