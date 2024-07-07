using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeakPerformance.Persistence.Configurations._Base;
using PeakPerformance.Domain.Entities.Audits;

namespace PeakPerformance.Persistence.Configurations.Audits;

internal class User_audConfiguration : Entity_audConfiguration<User_aud>
{
    protected override void ConfigureEntity(EntityTypeBuilder<User_aud> builder)
    {
    }
}