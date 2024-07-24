using System.ComponentModel;

namespace PeakPerformance.Common.Enums;

public enum eInjuryType
{
    [Description("Knee Injury")]
    KneeInjury = 1,

    [Description("Shoulder Injury")]
    ShoulderInjury = 2,

    [Description("Back Injury")]
    BackInjury = 3,

    [Description("Elbow Injury")]
    ElbowInjury = 4,

    [Description("Wrist Injury")]
    WristInjury = 5,

    [Description("Ankle Injury")]
    AnkleInjury = 6,

    [Description("Hip Injury")]
    HipInjury = 7,

    [Description("Neck Injury")]
    NeckInjury = 8,

    [Description("Asthma")]
    Asthma = 9,

    [Description("Heart Condition")]
    HeartCondition = 10,

    [Description("Diabetes")]
    Diabetes = 11,

    [Description("Arthritis")]
    Arthritis = 12,

    [Description("High Blood Pressure")]
    HighBloodPressure = 13,

    [Description("Low Blood Pressure")]
    LowBloodPressure = 14,

    [Description("Pregnancy")]
    Pregnancy = 15,

    [Description("Chronic Fatigue")]
    ChronicFatigue = 16,

    [Description("Scoliosis")]
    Scoliosis = 17,

    [Description("Plantar Fasciitis")]
    PlantarFasciitis = 18,

    [Description("Tendinitis")]
    Tendinitis = 19,

    [Description("Carpal Tunnel Syndrome")]
    CarpalTunnelSyndrome = 20,

    [Description("Chest Injury")]
    ChestInjury = 21,

    [Description("Bicep Injury")]
    BicepInjury = 22,

    [Description("Tricep Injury")]
    TricepInjury = 23,

    [Description("Quad Injury")]
    QuadInjury = 24,

    [Description("Hamstring Injury")]
    HamstringInjury = 25,
}