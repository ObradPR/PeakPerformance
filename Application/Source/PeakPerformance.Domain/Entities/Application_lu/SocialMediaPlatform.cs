namespace PeakPerformance.Domain.Entities.Application_lu;

[Lookup]
public class SocialMediaPlatform : BaseLookupDomain<SocialMediaPlatform, eSocialMediaPlatform>, IConfigurableEntity
{
    //
    // Relationships
    //

    #region Relationships

    [InverseProperty("Platform")]
    public virtual ICollection<SocialMedia> SocialMedia { get; set; }

    #endregion Relationships

    //
    // Configuration
    //

    public void Configure(ModelBuilder builder) => builder.Entity<SocialMediaPlatform>(ConfigureLookup);
}