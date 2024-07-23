using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeakPerformance.Domain.Entities.Audits;
using PeakPerformance.Persistence.Configurations._Base;

namespace PeakPerformance.Persistence.Configurations.Audits;

internal class UserRole_audConfiguraion : Entity_audConfiguration<UserRole_aud>
{
    protected override void ConfigureEntity(EntityTypeBuilder<UserRole_aud> builder)
    {
    }
}