using PeakPerformance.Domain.Entities._Base;
using PeakPerformance.Domain.Entities.Application_lu;

namespace PeakPerformance.Domain.Entities.Application;

public class BodyMeasurement : BaseEntity
{
    public BodyMeasurement() => RecordDate = DateTime.UtcNow;

    public long Id { get; set; }

    public long UserId { get; set; }

    public decimal? Waist { get; set; }

    public decimal? Hips { get; set; }

    public decimal? Neck { get; set; }

    public decimal? Chest { get; set; }

    public decimal? Shoulders { get; set; }

    public decimal? RightBicep { get; set; }

    public decimal? LeftBicep { get; set; }

    public decimal? RightForearm { get; set; }

    public decimal? LeftForearm { get; set; }

    public decimal? RightThigh { get; set; }

    public decimal? LeftThigh { get; set; }

    public decimal? RightCalf { get; set; }

    public decimal? LeftCalf { get; set; }

    public int MeasurementUnitId { get; set; }

    public DateTime RecordDate { get; set; }

    // Relationships

    public virtual User User { get; set; }

    public virtual MeasurementUnit MeasurementUnit { get; set; }
}