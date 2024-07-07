using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeakPerformance.Common.Extensions;
using PeakPerformance.Domain.Entities._Base;

namespace PeakPerformance.Persistence.Configurations._Base;

internal abstract class Entity_luConfiguration<T> : IEntityTypeConfiguration<T>
    where T : Entity_lu
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.ToTable(typeof(T).Name.ToPlural() + "_lu");

        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.Name)
            .IsRequired()
            .HasMaxLength(30);

        builder.HasIndex(_ => _.Name)
            .IsUnique();

        ConfigureEntity(builder);
    }

    protected abstract void ConfigureEntity(EntityTypeBuilder<T> builder);
}