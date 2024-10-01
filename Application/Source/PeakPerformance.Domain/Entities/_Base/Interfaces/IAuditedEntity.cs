namespace PeakPerformance.Domain.Entities._Base.Interfaces;

public interface IAuditedEntity : ISoftDelete
{
    DateTime CreatedOn { get; set; }

    long CreatedBy { get; set; }

    DateTime? ModifiedOn { get; set; }

    long? ModifiedBy { get; set; }
}