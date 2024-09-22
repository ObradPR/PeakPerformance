using PeakPerformance.Domain.Entities._Base;
using PeakPerformance.Domain.Entities.Application_lu;

namespace PeakPerformance.Domain.Entities.Application;

public class Weight : _BaseEntity
{
    public Weight() => RecordDate = DateTime.UtcNow;

    public long Id { get; set; }

    public long UserId { get; set; }

    public decimal Value { get; set; }

    public int WeightUnitId { get; set; }

    public decimal? BodyFatPercentage { get; set; }

    public DateTime RecordDate { get; set; }

    // Relationships

    public virtual User User { get; set; }

    public virtual MeasurementUnit WeightUnit { get; set; }
}