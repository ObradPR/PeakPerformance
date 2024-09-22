using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeakPerformance.Domain.Entities.Audits;
using PeakPerformance.Persistence.Configurations._Base;

namespace PeakPerformance.Persistence.Configurations.Audits;

internal class User_audConfiguration : Entity_audConfiguration<User_aud>
{
    protected override void ConfigureEntity(EntityTypeBuilder<User_aud> builder)
    {
    }
}