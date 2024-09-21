namespace PeakPerformance.Common.Extensions;

public static partial class Extensions
{
    public static bool Toggle(this bool value)
        => !value;

    public static int ToInt(this bool value)
        => value ? 1 : 0;

    public static void IfTrue(this bool value, Action action)
    {
        if (value) action();
    }

    public static void IfFalse(this bool value, Action action)
    {
        if (!value) action();
    }

    public static Action ToAction(this bool value, Action trueAction, Action falseAction)
        => value
        ? trueAction
        : falseAction;
}