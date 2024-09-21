namespace PeakPerformance.Application.Dtos.SocialMedia;

public class SocialMediaDto
{
    [Description("Social Media Platform")]
    public eSocialMediaPlatform PlatformId { get; set; }

    [Description("Link")]
    public string Link { get; set; } = string.Empty;
}