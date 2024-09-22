using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeakPerformance.Domain.Entities.Audits;
using PeakPerformance.Persistence.Configurations._Base;

namespace PeakPerformance.Persistence.Configurations.Audits;

internal class UserMeasurementPreference_audConfiguration : Entity_audConfiguration<UserMeasurementPreference_aud>
{
    protected override void ConfigureEntity(EntityTypeBuilder<UserMeasurementPreference_aud> builder)
    {
    }
}