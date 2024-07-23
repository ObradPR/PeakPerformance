using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeakPerformance.Domain.Entities.Application;
using PeakPerformance.Persistence.Configurations._Base;

namespace PeakPerformance.Persistence.Configurations.Application;

internal class UserTrainingGoalConfiguration : EntityConfiguration<UserTrainingGoal>
{
    protected override void ConfigureEntity(EntityTypeBuilder<UserTrainingGoal> builder)
    {
        builder.ToTable(_ => _.HasTrigger(Extensions.Extensions.GetAuditTriggerName<UserTrainingGoal>()));

        // Relationships

        builder.HasOne(_ => _.User)
            .WithMany(u => u.UserTrainingGoals)
            .HasForeignKey(_ => _.UserId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(_ => _.TrainingGoal)
            .WithMany(tg => tg.UserTrainingGoals)
            .HasForeignKey(_ => _.TrainingGoalId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}