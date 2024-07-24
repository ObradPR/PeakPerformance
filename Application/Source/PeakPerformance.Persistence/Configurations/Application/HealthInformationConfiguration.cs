using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeakPerformance.Domain.Entities.Application;
using PeakPerformance.Persistence.Configurations._Base;

namespace PeakPerformance.Persistence.Configurations.Application;

internal class HealthInformationConfiguration : EntityConfiguration<HealthInformation>
{
    protected override void ConfigureEntity(EntityTypeBuilder<HealthInformation> builder)
    {
        builder.ToTable(_ => _.HasTrigger(Extensions.Extensions.GetAuditTriggerName<HealthInformation>(false)));

        // Relationships

        builder.HasOne(_ => _.User)
            .WithMany(u => u.HealthInformation)
            .HasForeignKey(_ => _.UserId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(_ => _.InjuryType)
            .WithMany(it => it.HealthInformation)
            .HasForeignKey(_ => _.InjuryTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}