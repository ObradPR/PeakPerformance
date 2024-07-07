namespace PeakPerformance.Domain.Entities._Base;

public abstract class Audit : IAudit
{
    public long AuditId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public long? ModifiedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public long? DeletedBy { get; set; }

    public bool? IsActive { get; set; }

    public string? DetailsJson { get; set; }
}