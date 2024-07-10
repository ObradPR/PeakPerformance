using System.ComponentModel;

namespace PeakPerformance.Common.Enums;

public enum eActionType
{
    [Description("Create")]
    Create = 1,

    [Description("Update")]
    Update = 2,

    [Description("Delete")]
    Delete = 3,

    [Description("Sign in")]
    Signin = 4,

    [Description("Sign out")]
    Signout = 5,

    //[Description("Read")]
    //Read = 6
}