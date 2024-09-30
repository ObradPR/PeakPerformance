namespace PeakPerformance.Domain.Entities.Application_lu;

[Lookup]
public class SystemRole : BaseLookupDomain<SystemRole, eSystemRole>, IConfigurableEntity
{
    #region Relationships

    [InverseProperty(nameof(UserRole.Role))]
    public virtual ICollection<UserRole> UserRoles { get; set; } = [];

    #endregion Relationships

    public void Configure(ModelBuilder builder) => builder.Entity<SystemRole>(ConfigureLookup);
}