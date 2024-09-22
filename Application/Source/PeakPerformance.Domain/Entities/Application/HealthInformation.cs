using PeakPerformance.Domain.Entities._Base;
using PeakPerformance.Domain.Entities.Application_lu;

namespace PeakPerformance.Domain.Entities.Application;

public class HealthInformation : AuditableEntity
{
    public long? UserId { get; set; }

    public int InjuryTypeId { get; set; }

    public string Description { get; set; } = string.Empty;

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    // Relationships

    public virtual User User { get; set; }

    public virtual InjuryType InjuryType { get; set; }

    // Override

    public override bool ShouldPluralize => false;
}