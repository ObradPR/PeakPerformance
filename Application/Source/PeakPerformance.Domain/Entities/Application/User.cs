using PeakPerformance.Common;

namespace PeakPerformance.Domain.Entities.Application;

public class User : BaseIndexAuditedDomain<User, long>, IConfigurableEntity
{
    public string FirstName { get; set; }

    public string MiddleName { get; set; }

    public string LastName { get; set; }

    public string FullName => $"{FirstName} {(MiddleName.IsNotNullOrEmpty() ? MiddleName + " " : "")}{LastName}";

    public string Username { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    [Column(TypeName = Constants.DB_TYPE_DATE)]
    public DateTime DateOfBirth { get; set; }

    public string PhoneNumber { get; set; }

    public string Description { get; set; }

    public bool ReceiveAppNews { get; set; } = false;

    // Image
    public string ProfilePictureUrl { get; set; }

    public string PublicId { get; set; }

    //
    // Relationships
    //

    #region Relationships

    [InverseProperty(nameof(User))]
    public virtual ICollection<UserRole> UserRoles { get; set; } = [];

    [InverseProperty(nameof(User))]
    public virtual ICollection<UserActivityLog> UserActivityLogs { get; set; } = [];

    [InverseProperty(nameof(User))]
    public virtual ICollection<UserMeasurementPreference> UserMeasurementPreferences { get; set; } = [];

    [InverseProperty(nameof(User))]
    public virtual ICollection<Weight> Weights { get; set; } = [];

    [InverseProperty(nameof(User))]
    public virtual ICollection<BodyMeasurement> BodyMeasurements { get; set; } = [];

    [InverseProperty(nameof(User))]
    public virtual ICollection<UserTrainingGoal> UserTrainingGoals { get; set; } = [];

    [InverseProperty(nameof(User))]
    public virtual ICollection<WeightGoal> WeightsGoals { get; set; } = [];

    [InverseProperty(nameof(User))]
    public virtual ICollection<BodyFatGoal> BodyFatGoals { get; set; } = [];

    [InverseProperty(nameof(User))]
    public virtual ICollection<SocialMedia> SocialMedia { get; set; } = [];

    [InverseProperty(nameof(User))]
    public virtual ICollection<HealthInformation> HealthInformation { get; set; } = [];

    #endregion Relationships

    //
    // Indexes
    //

    #region Indexes

    public static IDatabaseIndex IX_Users_Email => new DatabaseIndex(nameof(IX_Users_Email))
    {
        Columns = { nameof(Email) },
        IsUnique = true,
    };

    public static IDatabaseIndex IX_Users_Username => new DatabaseIndex(nameof(IX_Users_Username))
    {
        Columns = { nameof(Username) },
        IsUnique = true,
    };

    public static IDatabaseIndex IX_Users_Name_DOB => new DatabaseIndex(nameof(IX_Users_Name_DOB))
    {
        Columns = { nameof(FirstName), nameof(MiddleName), nameof(LastName) },
        Include = { nameof(DateOfBirth) }
    };

    #endregion Indexes

    //
    // Configuration
    //
    public void Configure(ModelBuilder builder)
    {
        builder.Entity<User>(_ =>
        {
            _.Property(_ => _.FirstName).HasMaxLength(20).IsRequired();
            _.Property(_ => _.MiddleName).HasMaxLength(20);
            _.Property(_ => _.LastName).HasMaxLength(30).IsRequired();
            _.Property(_ => _.Username).HasMaxLength(30).IsRequired();
            _.Property(_ => _.Email).HasMaxLength(100).IsRequired();
            _.Property(_ => _.Password).IsRequired();
            _.Property(_ => _.DateOfBirth).IsRequired();
            _.Property(_ => _.PhoneNumber).HasMaxLength(15).IsRequired();
            _.Property(_ => _.Description).HasMaxLength(500);
        });
    }
}