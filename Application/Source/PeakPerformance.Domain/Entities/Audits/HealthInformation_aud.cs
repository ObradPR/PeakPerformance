namespace PeakPerformance.Domain.Entities.Audits;

[Audit]
[NoPlural]
public class HealthInformation_aud : AuditDomain<long>
{
    public long? UserId { get; set; }

    public eInjuryType? InjuryTypeId { get; set; }
}