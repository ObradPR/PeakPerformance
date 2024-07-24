using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeakPerformance.Domain.Entities.Application;

namespace PeakPerformance.Persistence.Configurations.Application;

internal class SocialMediaConfiguration : IEntityTypeConfiguration<SocialMedia>
{
    public void Configure(EntityTypeBuilder<SocialMedia> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.Link)
            .IsRequired()
            .HasMaxLength(255);

        // Relationships

        builder.HasOne(_ => _.User)
            .WithMany(u => u.SocialMedia)
            .HasForeignKey(_ => _.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(_ => _.Platform)
            .WithMany(smp => smp.SocialMedia)
            .HasForeignKey(_ => _.PlatformId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}