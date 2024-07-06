using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeakPerformance.Domain.Entities.Application;

namespace PeakPerformance.Persistence.Configurations.Application;

internal class ErrorLogConfiguration : IEntityTypeConfiguration<ErrorLog>
{
    public void Configure(EntityTypeBuilder<ErrorLog> builder)
    {
        builder.HasKey(_ => _.Id);

        builder
            .Property(_ => _.Message)
            .IsRequired();
    }
}