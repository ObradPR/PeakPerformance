using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeakPerformance.Persistence.Configurations._Base;
using PeakPerformance.Domain.Entities.Audits;

namespace PeakPerformance.Persistence.Configurations.Audits;

internal class UserRole_audConfiguraion : Entity_audConfiguration<UserRole_aud>
{
    protected override void ConfigureEntity(EntityTypeBuilder<UserRole_aud> builder)
    {
    }
}