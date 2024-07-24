using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeakPerformance.Domain.Entities.Audits;
using PeakPerformance.Persistence.Configurations._Base;

namespace PeakPerformance.Persistence.Configurations.Audits;

internal class HealthInformation_audConfiguration : Entity_audConfiguration<HealthInformation_aud>
{
    protected override void ConfigureEntity(EntityTypeBuilder<HealthInformation_aud> builder)
    {
        builder.ToTable(nameof(HealthInformation_aud));
    }
}