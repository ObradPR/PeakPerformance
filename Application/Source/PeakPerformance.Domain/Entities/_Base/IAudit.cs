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

    string? DetailsJson { get; set; }
}