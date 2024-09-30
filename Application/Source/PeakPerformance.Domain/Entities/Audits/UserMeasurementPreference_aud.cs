namespace PeakPerformance.Domain.Entities.Audits;

public class UserMeasurementPreference_aud : AuditDomain<long>
{
    public long? UserId { get; set; }
}