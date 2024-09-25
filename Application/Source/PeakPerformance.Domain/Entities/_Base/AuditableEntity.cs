namespace PeakPerformance.Domain.Entities._Base;

public abstract partial class AuditableEntity : BaseEntity, IAuditableEntity
{
    public AuditableEntity()
    {
        CreatedOn = DateTime.UtcNow;
        IsActive = true;
    }

    public long Id { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public long? ModifiedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public long? DeletedBy { get; set; }

    public bool IsActive { get; set; }
}