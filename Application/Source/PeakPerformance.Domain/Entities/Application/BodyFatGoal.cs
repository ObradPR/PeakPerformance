using PeakPerformance.Domain.Entities._Base;

namespace PeakPerformance.Domain.Entities.Application;

public class BodyFatGoal : BaseEntity
{
    public BodyFatGoal() => RecordDate = DateTime.UtcNow;

    public long Id { get; set; }

    public long UserId { get; set; }

    public decimal TargetBodyFatPercentage { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime RecordDate { get; set; }

    // Relationships

    public virtual User User { get; set; }
}