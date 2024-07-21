using System.ComponentModel;

namespace PeakPerformance.Common.Enums;

public enum eMeasurementUnit
{
    [Description("kg")]
    Kilograms = 1,

    [Description("lbs")]
    Pounds = 2,

    [Description("cm")]
    Centimeters = 3,

    [Description("in")]
    Inches = 4
}