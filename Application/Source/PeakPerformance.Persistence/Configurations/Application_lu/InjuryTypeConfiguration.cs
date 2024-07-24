using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeakPerformance.Domain.Entities.Application_lu;
using PeakPerformance.Persistence.Configurations._Base;

namespace PeakPerformance.Persistence.Configurations.Application_lu;

internal class InjuryTypeConfiguration : Entity_luConfiguration<InjuryType>
{
    protected override void ConfigureEntity(EntityTypeBuilder<InjuryType> builder)
    {
    }
}