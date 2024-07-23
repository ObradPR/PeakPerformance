using PeakPerformance.Domain.Entities._Base;
using PeakPerformance.Domain.Entities.Application_lu;

namespace PeakPerformance.Domain.Entities.Application;

public class UserTrainingGoal : AuditableEntity
{
    public long? UserId { get; set; }

    public int TrainingGoalId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    // Relationships

    public virtual User User { get; set; }

    public virtual TrainingGoal TrainingGoal { get; set; }
}