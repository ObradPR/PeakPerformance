namespace PeakPerformance.Application.Dtos.BodyMeasurements;

public class BodyMeasurementDto
{
    [Display(Name = "Waist")]
    public decimal? Waist { get; set; }

    [Display(Name = "Hips")]
    public decimal? Hips { get; set; }

    [Display(Name = "Neck")]
    public decimal? Neck { get; set; }

    [Display(Name = "Chest")]
    public decimal? Chest { get; set; }

    [Display(Name = "Shoulders")]
    public decimal? Shoulders { get; set; }

    [Display(Name = "Right Bicep")]
    public decimal? RightBicep { get; set; }

    [Display(Name = "Left Bicep")]
    public decimal? LeftBicep { get; set; }

    [Display(Name = "Right Forearm")]
    public decimal? RightForearm { get; set; }

    [Display(Name = "Left Forearm")]
    public decimal? LeftForearm { get; set; }

    [Display(Name = "Right Thigh")]
    public decimal? RightThigh { get; set; }

    [Display(Name = "Left Thigh")]
    public decimal? LeftThigh { get; set; }

    [Display(Name = "Right Calf")]
    public decimal? RightCalf { get; set; }

    [Display(Name = "Left Calf")]
    public decimal? LeftCalf { get; set; }

    [Display(Name = "Measurement Unit")]
    public eMeasurementUnit MeasurementUnitId { get; set; }
}