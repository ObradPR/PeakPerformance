using Microsoft.EntityFrameworkCore;
using PeakPerformance.Domain.Entities.Application_lu;

namespace PeakPerformance.Persistence.Contexts;

public partial class ApplicationDbContext
{
    public virtual DbSet<SystemRole> SystemRoles { get; set; }

    public virtual DbSet<ActionType> ActionTypes { get; set; }

    public virtual DbSet<MeasurementUnit> MeasurementsUnits { get; set; }

    public virtual DbSet<TrainingGoal> TrainingGoals { get; set; }

    public virtual DbSet<SocialMediaPlatform> SocialMediaPlatforms { get; set; }

    public virtual DbSet<InjuryType> InjuryTypes { get; set; }
}