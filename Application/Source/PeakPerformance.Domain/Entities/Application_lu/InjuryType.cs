namespace PeakPerformance.Domain.Entities.Application_lu;

[Lookup]
public class InjuryType : BaseLookupDomain<InjuryType, eInjuryType>, IConfigurableEntity
{
    //
    // Relationships
    //

    #region Relationships

    [InverseProperty(nameof(InjuryType))]
    public virtual ICollection<HealthInformation> HealthInformation { get; set; } = [];

    #endregion Relationships

    //
    // Configuration
    //

    public void Configure(ModelBuilder builder) => builder.Entity<InjuryType>(ConfigureLookup);
}