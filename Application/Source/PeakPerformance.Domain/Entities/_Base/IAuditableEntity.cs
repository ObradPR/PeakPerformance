namespace PeakPerformance.Domain.Entities._Base;

public interface IAuditableEntity
{
    long Id { get; set; }

    DateTime CreatedOn { get; set; }

    DateTime? ModifiedOn { get; set; }

    long? ModifiedBy { get; set; }

    DateTime? DeletedOn { get; set; }

    long? DeletedBy { get; set; }

    bool IsActive { get; set; }
}