namespace PeakPerformance.Domain.Entities.Audits;

[Audit]
public class ChallengeParticipant_aud : AuditDomain<long>
{
    public long? ChallengeId { get; set; }

    public long? UserId { get; set; }
}