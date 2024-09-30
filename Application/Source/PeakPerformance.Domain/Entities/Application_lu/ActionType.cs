namespace PeakPerformance.Domain.Entities.Application_lu;

[Lookup]
public class ActionType : BaseLookupDomain<ActionType, eActionType>, IConfigurableEntity
{
    #region Relationships

    [InverseProperty(nameof(ActionType))]
    public virtual ICollection<User_aud> Users_aud { get; set; } = [];

    [InverseProperty(nameof(ActionType))]
    public virtual ICollection<UserRole_aud> UserRoles_aud { get; set; } = [];

    [InverseProperty(nameof(ActionType))]
    public virtual ICollection<UserActivityLog> UserActivityLogs { get; set; } = [];

    #endregion Relationships

    public void Configure(ModelBuilder builder) => builder.Entity<ActionType>(ConfigureLookup);
}