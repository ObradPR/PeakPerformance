using PeakPerformance.Domain.Entities._Base;

namespace PeakPerformance.Domain.Entities.Audits;

public class HealthInformation_aud : Audit
{
    public long? Id { get; set; }

    public long? UserId { get; set; }

    // Override

    public override bool ShouldPluralize => false;
}