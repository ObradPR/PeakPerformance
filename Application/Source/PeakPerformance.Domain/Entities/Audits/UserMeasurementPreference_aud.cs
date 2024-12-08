namespace PeakPerformance.Domain.Entities.Audits;

[Audit]
public class UserMeasurementPreference_aud : AuditDomain<long>
{
    public long? UserId { get; set; }

    public eMeasurementUnit? WeightUnitId { get; set; }

    public eMeasurementUnit? MeasurementUnitId { get; set; }
}