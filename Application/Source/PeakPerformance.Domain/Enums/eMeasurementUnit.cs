namespace PeakPerformance.Domain.Enums;

public enum eMeasurementUnit
{
    [Description("")]
    NotSet = 0,

    [Description("kg")]
    Kilograms = 1,

    [Description("lbs")]
    Pounds = 2,

    [Description("cm")]
    Centimeters = 3,

    [Description("in")]
    Inches = 4
}