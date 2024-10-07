using SocialMedia_ = PeakPerformance.Domain.Entities.Application.SocialMedia;

namespace PeakPerformance.Application.Dtos.SocialMedia;

public class SocialMediaDto
{
    [Display(Name = "Social media platform")]
    public eSocialMediaPlatform PlatformId { get; set; }

    [Display(Name = "Link")]
    public string Link { get; set; }

    [Display(Name = "Phone number")]
    public string PhoneNumber { get; set; }

    // methods

    public void ToModel(SocialMedia_ model, long userId)
    {
        model.UserId = userId;
        model.PlatformId = PlatformId;
        model.Link = Link;
        model.PhoneNumber = PhoneNumber;
    }
}