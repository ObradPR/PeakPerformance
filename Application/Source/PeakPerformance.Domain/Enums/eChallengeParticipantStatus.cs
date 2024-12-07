namespace PeakPerformance.Domain.Enums;

public enum eChallengeParticipantStatus
{
    [Description("Joined")]
    Joined = 1,

    [Description("Completed")]
    Completed = 2,

    [Description("Dropped")]
    Dropped = 3,

    [Description("Disqualified")]
    Disqualified = 4,

    [Description("Pending")]
    Pending = 5,

    [Description("Inactive")]
    Inactive = 6,

    [Description("Failed")]
    Failed = 7,

    [Description("Suspended")]
    Suspended = 8,

    [Description("Mastered")]
    Mastered = 9
}