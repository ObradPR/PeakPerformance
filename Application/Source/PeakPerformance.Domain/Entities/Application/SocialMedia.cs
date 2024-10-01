namespace PeakPerformance.Domain.Entities.Application;

[NoPlural]
public class SocialMedia : BaseAuditedDomain<long>, IConfigurableEntity
{
    public long UserId { get; set; }

    public eSocialMediaPlatform PlatformId { get; set; }

    public string Link { get; set; }

    //
    // Relationships
    //

    #region Relationships

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }

    [ForeignKey(nameof(PlatformId))]
    public virtual SocialMediaPlatform Platform { get; set; }

    #endregion Relationships

    //
    // Configuration
    //

    public void Configure(ModelBuilder builder)
    {
        builder.Entity<SocialMedia>(_ =>
        {
            _.Property(_ => _.Link).HasMaxLength(255).IsRequired();
        });
    }
}