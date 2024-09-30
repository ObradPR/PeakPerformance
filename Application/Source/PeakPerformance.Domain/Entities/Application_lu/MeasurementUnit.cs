namespace PeakPerformance.Domain.Entities.Application_lu;

[Lookup]
public class MeasurementUnit : BaseLookupDomain<MeasurementUnit, eMeasurementUnit>, IConfigurableEntity
{
    #region Relationships

    [InverseProperty(nameof(UserMeasurementPreference.WeightUnit))]
    public virtual ICollection<UserMeasurementPreference> WeightUnitPreferences { get; set; } = [];

    [InverseProperty(nameof(MeasurementUnit))]
    public virtual ICollection<UserMeasurementPreference> MeasurementUnitPreferences { get; set; } = [];

    [InverseProperty(nameof(Weight.WeightUnit))]
    public virtual ICollection<Weight> Weights { get; set; } = [];

    [InverseProperty(nameof(MeasurementUnit))]
    public virtual ICollection<BodyMeasurement> BodyMeasurements { get; set; } = [];

    #endregion Relationships

    public void Configure(ModelBuilder builder) => builder.Entity<MeasurementUnit>(ConfigureLookup);
}