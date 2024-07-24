using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeakPerformance.Domain.Entities.Application_lu;
using PeakPerformance.Persistence.Configurations._Base;

namespace PeakPerformance.Persistence.Configurations.Application_lu;

internal class SocialMediaPlatformConfiguration : Entity_luConfiguration<SocialMediaPlatform>
{
    protected override void ConfigureEntity(EntityTypeBuilder<SocialMediaPlatform> builder)
    {
    }
}