using System.ComponentModel;

namespace PeakPerformance.Common.Enums;

public enum eChallengeStatus
{
    [Description("Pending")]
    Pending = 1,

    [Description("Approved")]
    Approved = 2,

    [Description("In Progress")]
    InProgress = 3,

    [Description("Completed")]
    Completed = 4,

    [Description("Rejected")]
    Rejected = 5,

    [Description("Cancelled")]
    Cancelled = 6,

    [Description("Failed")]
    Failed = 7
}