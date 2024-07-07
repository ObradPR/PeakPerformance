namespace PeakPerformance.Common.Extensions;

public static partial class Extensions
{
    public static bool Toggle(this bool value)
        => !value;

    public static int ToInt(this bool value)
        => value ? 1 : 0;

    public static bool And(this bool value, params bool[] others)
    {
        if (!value)
            return false;

        foreach (var other in others)
            if (!other)
                return false;

        return true;
    }

    public static bool Or(this bool value, params bool[] others)
    {
        if (value)
            return true;

        foreach (var other in others)
            if (other)
                return true;

        return false;
    }

    public static bool Xor(this bool value, bool other)
        => value != other;

    public static bool Nand(this bool value, params bool[] others)
        => !value.And(others);

    public static bool Nor(this bool value, params bool[] others)
        => !value.Or(others);

    public static bool Not(this bool value)
        => !value;
}