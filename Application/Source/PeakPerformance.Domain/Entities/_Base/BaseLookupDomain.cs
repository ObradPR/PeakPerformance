using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PeakPerformance.Domain.Entities._Base;

public class BaseLookupDomain<T, TEnum> : BaseDomain<TEnum>, ILookupEntity
    where T : BaseLookupDomain<T, TEnum>
    where TEnum : struct, Enum
{
    public string Name { get; set; }

    //
    // Configuration
    //

    protected void ConfigureLookup(EntityTypeBuilder<T> entity)
    {
        entity.Property(nameof(Name))
            .HasMaxLength(30)
            .IsRequired();

        entity.HasIndex(nameof(Name)).IsUnique();
    }
}