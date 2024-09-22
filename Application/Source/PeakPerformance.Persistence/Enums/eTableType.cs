using System.ComponentModel;

namespace PeakPerformance.Persistence.Enums;

public enum eTableType
{
    [Description("")]
    Normal = 1,

    [Description("_lu")]
    Lookup = 2,

    [Description("_aud")]
    Audit = 3
}