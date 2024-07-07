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

    [Description("Login")]
    Login = 4,

    [Description("Logout")]
    Logout = 5,

    //[Description("Read")]
    //Read = 6
}