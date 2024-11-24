namespace PeakPerformance.Domain.Entities.Audits;

[Audit]
public class Challenge_aud : AuditDomain<long>
{
    public long? CreatedBy { get; set; }
}