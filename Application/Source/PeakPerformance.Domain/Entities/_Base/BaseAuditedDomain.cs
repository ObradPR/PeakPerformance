namespace PeakPerformance.Domain.Entities._Base;

public class BaseAuditedDomain<TKey> : BaseDomain<TKey>, IAuditedEntity
    where TKey : struct
{
    public DateTime CreatedOn { get; set; }

    public long CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public long? ModifiedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public long? DeletedBy { get; set; }

    public bool IsActive { get; set; }
}