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