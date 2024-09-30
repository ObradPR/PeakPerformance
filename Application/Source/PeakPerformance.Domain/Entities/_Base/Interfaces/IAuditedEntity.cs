namespace PeakPerformance.Domain.Entities._Base.Interfaces;

public interface IAuditedEntity
{
    DateTime? ModifiedOn { get; set; }

    long? ModifiedBy { get; set; }

    DateTime? DeletedOn { get; set; }

    long? DeletedBy { get; set; }

    bool IsActive { get; set; }
}