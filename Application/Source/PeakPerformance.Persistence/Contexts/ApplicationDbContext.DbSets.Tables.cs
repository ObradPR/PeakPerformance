namespace PeakPerformance.Persistence.Contexts;

public partial class ApplicationDbContext
{
    // Tables

    public virtual DbSet<ErrorLog> ErrorLogs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<UserActivityLog> UserActivityLogs { get; set; }

    public virtual DbSet<UserMeasurementPreference> UserMeasurementPreferences { get; set; }

    public virtual DbSet<Weight> Weights { get; set; }

    public virtual DbSet<BodyMeasurement> BodyMeasurements { get; set; }

    public virtual DbSet<UserTrainingGoal> UserTrainingGoals { get; set; }

    public virtual DbSet<WeightGoal> WeightGoals { get; set; }

    public virtual DbSet<BodyFatGoal> BodyFatGoals { get; set; }

    public virtual DbSet<SocialMedia> SocialMedia { get; set; }

    public virtual DbSet<HealthInformation> HealthInformation { get; set; }
}