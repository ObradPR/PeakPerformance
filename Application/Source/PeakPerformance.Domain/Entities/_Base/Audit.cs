using PeakPerformance.Domain.Entities.Application_lu;

namespace PeakPerformance.Domain.Entities._Base;

public abstract class Audit : _BaseEntity, IAudit
{
    public long AuditId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public long? ModifiedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public long? DeletedBy { get; set; }

    public bool? IsActive { get; set; }

    public int? ActionTypeId { get; set; }

    public string? DetailsJson { get; set; }

    // Relationships

    public virtual ActionType ActionType { get; set; }
}