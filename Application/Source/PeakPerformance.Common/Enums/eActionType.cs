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

    [Description("Deactivate")]
    Deactivate = 4,

    [Description("Sign up")]
    Signup = 5,

    [Description("Sign in")]
    Signin = 6,

    [Description("Sign out")]
    Signout = 7,

    //[Description("Read")]
    //Read = 6
}