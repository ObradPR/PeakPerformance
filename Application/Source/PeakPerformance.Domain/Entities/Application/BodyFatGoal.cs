namespace PeakPerformance.Domain.Entities.Application;

public class BodyFatGoal : BaseAuditedDomain<long>, IConfigurableEntity
{
    public long UserId { get; set; }

    public decimal TargetBodyFatPercentage { get; set; }

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

    #endregion Relationships

    //
    // Configuration
    //

    public void Configure(ModelBuilder builder)
    {
        builder.Entity<BodyFatGoal>(_ =>
        {
            _.Property(_ => _.TargetBodyFatPercentage).HasPrecision(4, 2).IsRequired();
        });
    }
}