using PeakPerformance.Domain.Entities.Application_lu;

namespace PeakPerformance.Domain.Entities._Base;

public interface IAudit
{
    public long AuditId { get; set; }

    DateTime? CreatedOn { get; set; }

    DateTime? ModifiedOn { get; set; }

    long? ModifiedBy { get; set; }

    DateTime? DeletedOn { get; set; }

    long? DeletedBy { get; set; }

    bool? IsActive { get; set; }

    int? ActionTypeId { get; set; }

    string? DetailsJson { get; set; }

    // Relationships

    ActionType ActionType { get; set; }
}