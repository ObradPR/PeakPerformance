namespace PeakPerformance.Common.Extensions;

public static partial class Extensions
{
    public static bool Toggle(this bool value) => !value;

    public static int ToInt(this bool value) => value ? 1 : 0;
}