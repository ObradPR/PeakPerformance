namespace PeakPerformance.Domain.Entities.Application_lu;

[Lookup]
public class ChallengeParticipantStatus : BaseLookupDomain<ChallengeParticipantStatus, eChallengeParticipantStatus>, IConfigurableEntity
{
    //
    // Relationships
    //

    #region Relationships

    [InverseProperty(nameof(ChallengeParticipant.Status))]
    public virtual ICollection<ChallengeParticipant> ChallengeParticipants { get; set; } = [];

    #endregion Relationships

    //
    // Configuration
    //

    public void Configure(ModelBuilder builder) => builder.Entity<ChallengeParticipantStatus>(ConfigureLookup);
}