namespace PeakPerformance.Domain.Entities.Audits;

[Audit]
public class UserMeasurementPreference_aud : AuditDomain<long>
{
    public long? UserId { get; set; }
}