namespace PeakPerformance.Domain.Entities.Application;

public class UserMeasurementPreference : BaseIndexAuditedDomain<UserMeasurementPreference, long>
{
    public long UserId { get; set; }

    public eMeasurementUnit WeightUnitId { get; set; }

    public eMeasurementUnit MeasurementUnitId { get; set; }

    //
    // Relationships
    //

    #region Relationships

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }

    [ForeignKey(nameof(WeightUnitId))]
    public virtual MeasurementUnit WeightUnit { get; set; }

    [ForeignKey(nameof(MeasurementUnitId))]
    public virtual MeasurementUnit MeasurementUnit { get; set; }

    #endregion Relationships

    //
    // Indexes
    //

    #region Indexes

    public static IDatabaseIndex IX_UserMeasurementPreferences_UserId_WeightUnitId_MeasurementUnitId => new DatabaseIndex(nameof(IX_UserMeasurementPreferences_UserId_WeightUnitId_MeasurementUnitId))
    {
        Columns = { nameof(UserId), nameof(WeightUnitId), nameof(MeasurementUnitId) },
        IsUnique = true
    };

    #endregion Indexes
}