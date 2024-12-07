using PeakPerformance.Domain.Enums.Attributes;

namespace PeakPerformance.Domain.Enums;

public enum eInjuryType
{
    [Description("")]
    NotSet = 0,

    [Injury]
    [Description("Knee Injury")]
    KneeInjury = 1,

    [Injury]
    [Description("Shoulder Injury")]
    ShoulderInjury = 2,

    [Injury]
    [Description("Back Injury")]
    BackInjury = 3,

    [Injury]
    [Description("Elbow Injury")]
    ElbowInjury = 4,

    [Injury]
    [Description("Wrist Injury")]
    WristInjury = 5,

    [Injury]
    [Description("Ankle Injury")]
    AnkleInjury = 6,

    [Injury]
    [Description("Hip Injury")]
    HipInjury = 7,

    [Injury]
    [Description("Neck Injury")]
    NeckInjury = 8,

    [Condition]
    [Description("Asthma")]
    Asthma = 9,

    [Condition]
    [Description("Heart Condition")]
    HeartCondition = 10,

    [Condition]
    [Description("Diabetes")]
    Diabetes = 11,

    [Condition]
    [Description("Arthritis")]
    Arthritis = 12,

    [Condition]
    [Description("High Blood Pressure")]
    HighBloodPressure = 13,

    [Condition]
    [Description("Low Blood Pressure")]
    LowBloodPressure = 14,

    [Condition]
    [Description("Pregnancy")]
    Pregnancy = 15,

    [Condition]
    [Description("Chronic Fatigue")]
    ChronicFatigue = 16,

    [Condition]
    [Description("Scoliosis")]
    Scoliosis = 17,

    [Condition]
    [Description("Plantar Fasciitis")]
    PlantarFasciitis = 18,

    [Condition]
    [Description("Tendinitis")]
    Tendinitis = 19,

    [Condition]
    [Description("Carpal Tunnel Syndrome")]
    CarpalTunnelSyndrome = 20,

    [Injury]
    [Description("Chest Injury")]
    ChestInjury = 21,

    [Injury]
    [Description("Bicep Injury")]
    BicepInjury = 22,

    [Injury]
    [Description("Tricep Injury")]
    TricepInjury = 23,

    [Injury]
    [Description("Quad Injury")]
    QuadInjury = 24,

    [Injury]
    [Description("Hamstring Injury")]
    HamstringInjury = 25,
}