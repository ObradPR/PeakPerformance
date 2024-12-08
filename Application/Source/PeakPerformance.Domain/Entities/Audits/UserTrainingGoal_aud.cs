namespace PeakPerformance.Domain.Entities.Audits;

[Audit]
public class UserTrainingGoal_aud : AuditDomain<long>
{
    public long? UserId { get; set; }

    public eTrainingGoal? TrainingGoalId { get; set; }
}