using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeakPerformance.Domain.Entities._Base;
using PeakPerformance.Persistence.Enums;
using PeakPerformance.Persistence.Extensions;

namespace PeakPerformance.Persistence.Configurations._Base;

internal abstract class Entity_audConfiguration<T> : IEntityTypeConfiguration<T>
    where T : Audit
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.ToTable(Extensions.Extensions.GetTableName<T>(eTableType.Audit));

        builder.HasKey(_ => _.AuditId);

        // Relationships

        builder.ConfigureAuditRelationship();

        ConfigureEntity(builder);
    }

    protected abstract void ConfigureEntity(EntityTypeBuilder<T> builder);
}