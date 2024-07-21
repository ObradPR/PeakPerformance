using PeakPerformance.Domain.Entities._Base;
using PeakPerformance.Domain.Entities.Application;

namespace PeakPerformance.Domain.Entities.Application_lu;

public class MeasurementUnit : Entity_lu
{
    // Relationships

    public virtual ICollection<UserMeasurementPreference> WeightUnitPreferences { get; set; } = [];

    public virtual ICollection<UserMeasurementPreference> MeasurementUnitPreferences { get; set; } = [];
}