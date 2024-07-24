using PeakPerformance.Domain.Entities.Application_lu;

namespace PeakPerformance.Domain.Entities.Application;

public class SocialMedia
{
    public SocialMedia() => RecordDate = DateTime.UtcNow;

    public long Id { get; set; }

    public long UserId { get; set; }

    public int PlatformId { get; set; }

    public string Link { get; set; } = string.Empty;

    public DateTime RecordDate { get; set; }

    // Relationships

    public virtual User User { get; set; }

    public virtual SocialMediaPlatform Platform { get; set; }
}