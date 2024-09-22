using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeakPerformance.Domain.Entities._Base;
using PeakPerformance.Persistence.Enums;

namespace PeakPerformance.Persistence.Configurations._Base;

internal abstract class Entity_luConfiguration<T> : IEntityTypeConfiguration<T>
    where T : Entity_lu
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.ToTable(Extensions.Extensions.GetTableName<T>(eTableType.Lookup));

        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.Name)
            .IsRequired()
            .HasMaxLength(30);

        // Indexes

        builder.HasIndex(_ => _.Name)
            .IsUnique();

        ConfigureEntity(builder);
    }

    protected abstract void ConfigureEntity(EntityTypeBuilder<T> builder);
}