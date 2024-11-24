namespace PeakPerformance.Domain.Entities.Application_lu;

[Lookup]
public class ChallengeStatus : BaseLookupDomain<ChallengeStatus, eChallengeStatus>, IConfigurableEntity
{
    //
    // Relationships
    //

    #region Relationships

    [InverseProperty(nameof(Challenge.Status))]
    public virtual ICollection<Challenge> Challenges { get; set; } = [];

    #endregion Relationships

    //
    // Configuration
    //

    public void Configure(ModelBuilder builder) => builder.Entity<ChallengeStatus>(ConfigureLookup);
}