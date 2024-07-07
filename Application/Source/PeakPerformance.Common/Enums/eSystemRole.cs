using System.ComponentModel;

namespace PeakPerformance.Common.Enums;

public enum eSystemRole
{
    [Description("Admin")]
    Admin = 1,

    [Description("User")]
    User = 2,

    [Description("Guest")]
    Guest = 3,

    //[Description("Coach")]
    //Coach = 4,
}