namespace PeakPerformance.Application.Dtos.SocialMedia;

public class SocialMediaDto
{
    [Display(Name = "Social Media Platform")]
    public eSocialMediaPlatform PlatformId { get; set; }

    [Display(Name = "Link")]
    public string Link { get; set; }
}