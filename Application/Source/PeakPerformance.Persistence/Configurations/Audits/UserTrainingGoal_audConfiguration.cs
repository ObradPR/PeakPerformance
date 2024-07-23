using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeakPerformance.Persistence.Configurations._Base;
using PeakPerformance.Domain.Entities.Audits;

namespace PeakPerformance.Persistence.Configurations.Audits;

internal class UserTrainingGoal_audConfiguration : Entity_audConfiguration<UserTrainingGoal_aud>
{
    protected override void ConfigureEntity(EntityTypeBuilder<UserTrainingGoal_aud> builder)
    {
    }
}