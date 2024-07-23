using PeakPerformance.Domain.Entities._Base;
using PeakPerformance.Domain.Entities.Application;

namespace PeakPerformance.Domain.Entities.Application_lu;

public class TrainingGoal : Entity_lu
{
    // Relationships

    public virtual ICollection<UserTrainingGoal> UserTrainingGoals { get; set; } = [];
}