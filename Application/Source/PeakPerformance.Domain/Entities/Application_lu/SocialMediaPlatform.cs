using PeakPerformance.Domain.Entities._Base;
using PeakPerformance.Domain.Entities.Application;

namespace PeakPerformance.Domain.Entities.Application_lu;

public class SocialMediaPlatform : Entity_lu
{
    // Relationships

    public virtual ICollection<SocialMedia> SocialMedia { get; set; }
}