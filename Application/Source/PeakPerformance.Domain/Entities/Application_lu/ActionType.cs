namespace PeakPerformance.Domain.Entities.Application_lu;

[Lookup]
public class ActionType : BaseLookupDomain<ActionType, eActionType>, IConfigurableEntity
{
    //
    // Relationships
    //

    #region Relationships

    [InverseProperty(nameof(ActionType))]
    public virtual ICollection<UserActivityLog> UserActivityLogs { get; set; } = [];

    [InverseProperty(nameof(ActionType))]
    public virtual ICollection<User_aud> Users_aud { get; set; } = [];

    [InverseProperty(nameof(ActionType))]
    public virtual ICollection<UserRole_aud> UserRoles_aud { get; set; } = [];

    [InverseProperty(nameof(ActionType))]
    public virtual ICollection<HealthInformation_aud> HealthInformation_aud { get; set; } = [];

    [InverseProperty(nameof(ActionType))]
    public virtual ICollection<UserMeasurementPreference_aud> UserMeasurementPreference_aud { get; set; } = [];

    [InverseProperty(nameof(ActionType))]
    public virtual ICollection<UserTrainingGoal_aud> UserTrainingGoal_aud { get; set; } = [];

    #endregion Relationships

    //
    // Configuration
    //

    public void Configure(ModelBuilder builder) => builder.Entity<ActionType>(ConfigureLookup);
}