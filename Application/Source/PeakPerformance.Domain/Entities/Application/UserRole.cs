namespace PeakPerformance.Domain.Entities.Application;

public class UserRole : BaseIndexAuditedDomain<UserRole, long>
{
    public long UserId { get; set; }

    public eSystemRole RoleId { get; set; }

    //
    // Relationships
    //

    #region Relationships

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }

    [ForeignKey(nameof(RoleId))]
    public virtual SystemRole Role { get; set; }

    #endregion Relationships

    //
    // Indexes
    //

    #region Indexes

    public static IDatabaseIndex IX_UserRoles_UserId_RoleId => new DatabaseIndex(nameof(IX_UserRoles_UserId_RoleId))
    {
        Columns = { nameof(UserId), nameof(RoleId) },
        IsUnique = true
    };

    #endregion Indexes
}