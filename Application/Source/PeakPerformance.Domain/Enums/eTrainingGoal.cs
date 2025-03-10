﻿namespace PeakPerformance.Domain.Enums;

public enum eTrainingGoal
{
    [Description("")]
    NotSet = 0,

    [Description("Strength")]
    Strength = 1,

    [Description("Bulking")]
    Bulking = 2,

    [Description("Cutting")]
    Cutting = 3,

    [Description("Cardio")]
    Cardio = 4,

    [Description("Explosivness")]
    Explosivness = 5,

    [Description("Endurance")]
    Endurance = 6,

    [Description("Flexibility")]
    Flexibility = 7,

    [Description("Balance")]
    Balance = 8,

    [Description("Agility")]
    Agility = 9
}