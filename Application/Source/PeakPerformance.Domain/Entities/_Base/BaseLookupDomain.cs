using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PeakPerformance.Domain.Entities._Base;

public class BaseLookupDomain<TLookup, TEnum> : BaseDomain<TEnum>, ILookupEntity
    where TLookup : BaseLookupDomain<TLookup, TEnum>
    where TEnum : struct, Enum
{
    public string Name { get; set; }

    protected void ConfigureLookup(EntityTypeBuilder<TLookup> entity)
    {
        entity.Property(nameof(Name))
            .HasMaxLength(30)
            .IsRequired();

        entity.HasIndex(nameof(Name)).IsUnique();
    }
}