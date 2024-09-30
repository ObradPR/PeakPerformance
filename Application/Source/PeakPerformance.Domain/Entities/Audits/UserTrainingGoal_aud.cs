namespace PeakPerformance.Domain.Entities.Audits;

public class UserTrainingGoal_aud : AuditDomain<long>
{
    public long? UserId { get; set; }
}