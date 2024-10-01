namespace PeakPerformance.Domain.Entities._Base.Interfaces;

public interface ISoftDelete
{
    DateTime? DeletedOn { get; set; }

    long? DeletedBy { get; set; }

    bool IsActive { get; set; }
}