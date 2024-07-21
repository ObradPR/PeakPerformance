using PeakPerformance.Domain.Entities._Base;
using PeakPerformance.Domain.Entities.Application_lu;

namespace PeakPerformance.Domain.Entities.Application;

public class UserMeasurementPreference : AuditableEntity
{
    public long? UserId { get; set; }

    public int WeightUnitId { get; set; }

    public int MeasurementUnitId { get; set; }

    // Relationships

    public virtual User User { get; set; }

    public virtual MeasurementUnit WeightUnit { get; set; }

    public virtual MeasurementUnit MeasurementUnit { get; set; }
}