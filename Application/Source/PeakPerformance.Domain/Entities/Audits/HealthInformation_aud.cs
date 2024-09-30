namespace PeakPerformance.Domain.Entities.Audits;

[NoPlural]
public class HealthInformation_aud : AuditDomain<long>
{
    public long? UserId { get; set; }
}