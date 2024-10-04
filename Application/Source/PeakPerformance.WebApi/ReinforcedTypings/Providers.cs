using PeakPerformance.Common.Enums;
using PeakPerformance.WebApi.ReinforcedTypings.Generator;

namespace PeakPerformance.WebApi.ReinforcedTypings;

public enum Providers
{
    [EnumProvider<eInjuryType>]
    InjuryTypes,

    [EnumProvider<eMeasurementUnit>]
    MeasurementUnits,

    [EnumProvider<eSocialMediaPlatform>]
    SocialMediaPlatforms,

    [EnumProvider<eTrainingGoal>]
    TrainingGoals,
}