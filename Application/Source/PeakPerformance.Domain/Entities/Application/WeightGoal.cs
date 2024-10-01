namespace PeakPerformance.Domain.Entities.Application;

public class WeightGoal : BaseAuditedDomain<long>, IConfigurableEntity
{
    public long UserId { get; set; }

    public decimal TargetWeight { get; set; }

    public DateTime StartDate { get; set; }

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
        builder.Entity<WeightGoal>(_ =>
        {
            _.Property(_ => _.TargetWeight).HasPrecision(5, 2).IsRequired();
        });
    }
}