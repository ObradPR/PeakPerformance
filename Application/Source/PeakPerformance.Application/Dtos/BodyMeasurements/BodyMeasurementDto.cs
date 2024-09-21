namespace PeakPerformance.Application.Dtos.BodyMeasurements;

public class BodyMeasurementDto
{
    [Description("Waist")]
    public decimal? Waist { get; set; }

    [Description("Hips")]
    public decimal? Hips { get; set; }

    [Description("Neck")]
    public decimal? Neck { get; set; }

    [Description("Chest")]
    public decimal? Chest { get; set; }

    [Description("Shoulders")]
    public decimal? Shoulders { get; set; }

    [Description("Right Bicep")]
    public decimal? RightBicep { get; set; }

    [Description("Left Bicep")]
    public decimal? LeftBicep { get; set; }

    [Description("Right Forearm")]
    public decimal? RightForearm { get; set; }

    [Description("Left Forearm")]
    public decimal? LeftForearm { get; set; }

    [Description("Right Thigh")]
    public decimal? RightThigh { get; set; }

    [Description("Left Thigh")]
    public decimal? LeftThigh { get; set; }

    [Description("Right Calf")]
    public decimal? RightCalf { get; set; }

    [Description("Left Calf")]
    public decimal? LeftCalf { get; set; }

    [Description("Measurement Unit")]
    public eMeasurementUnit MeasurementUnitId { get; set; }
}