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

    [Display(Name = "Right bicep")]
    public decimal? RightBicep { get; set; }

    [Display(Name = "Left bicep")]
    public decimal? LeftBicep { get; set; }

    [Display(Name = "Right forearm")]
    public decimal? RightForearm { get; set; }

    [Display(Name = "Left forearm")]
    public decimal? LeftForearm { get; set; }

    [Display(Name = "Right thigh")]
    public decimal? RightThigh { get; set; }

    [Display(Name = "Left thigh")]
    public decimal? LeftThigh { get; set; }

    [Display(Name = "Right calf")]
    public decimal? RightCalf { get; set; }

    [Display(Name = "Left calf")]
    public decimal? LeftCalf { get; set; }

    [Display(Name = "Measurement unit")]
    public eMeasurementUnit MeasurementUnitId { get; set; }

    // methods

    public void ToModel(BodyMeasurement model, long userId)
    {
        model.UserId = userId;
        model.Waist = Waist;
        model.Hips = Hips;
        model.Neck = Neck;
        model.Chest = Chest;
        model.Shoulders = Shoulders;
        model.RightBicep = RightBicep;
        model.LeftBicep = LeftBicep;
        model.RightForearm = RightForearm;
        model.LeftForearm = LeftForearm;
        model.RightThigh = RightThigh;
        model.LeftThigh = LeftThigh;
        model.RightCalf = RightCalf;
        model.LeftCalf = LeftCalf;
        model.MeasurementUnitId = MeasurementUnitId;
    }

    public bool HasAnyValue()
    {
        var properties = this.GetType()
            .GetProperties()
            .Where(_ => _.PropertyType == typeof(decimal?))
            .ToList();

        return properties.Exists(_ => _.GetValue(this) != null);
    }
}