namespace PeakPerformance.Persistence.Contexts;

public partial class ApplicationDbContext
{
    public virtual DbSet<User_aud> Users_aud { get; set; }

    public virtual DbSet<UserRole_aud> UserRoles_aud { get; set; }

    public virtual DbSet<UserMeasurementPreference_aud> UserMeasurementPreferences_aud { get; set; }

    public virtual DbSet<UserTrainingGoal_aud> UserTrainingGoals_aud { get; set; }

    public virtual DbSet<HealthInformation_aud> HealthInformation_aud { get; set; }
}