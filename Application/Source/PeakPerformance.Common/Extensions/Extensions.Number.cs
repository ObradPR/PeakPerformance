namespace PeakPerformance.Common.Extensions;

public static partial class Extensions
{
    public static bool IsEven(this int number)
        => number % 2 == 0;

    public static bool IsOdd(this int number)
        => number % 2 != 0;

    public static string ToCurrency(this decimal number)
        => string.Format("{0:C}", number);

    public static string ToPercentage(this double number, int decimalPlaces = 2)
        => string.Format("{0:P" + decimalPlaces + "}", number);

    public static int Clamp(this int number, int min, int max)
    {
        if (number < min)
            return min;

        if (number > max)
            return max;

        return number;
    }

    public static double RoundToNearest(this double number, double nearest)
        => Math.Round(number / nearest) * nearest;

    public static bool IsPrime(this int number)
    {
        if (number <= 1)
            return false;

        if (number == 2)
            return true;

        if (number % 2 == 0)
            return false;

        var boundary = (int)Math.Floor(Math.Sqrt(number));

        for (int i = 3; i <= boundary; i += 2)
            if (number % i == 0)
                return false;

        return true;
    }

    public static bool IsNumericType(Type type)
    {
        return type == typeof(byte) || type == typeof(sbyte) ||
               type == typeof(short) || type == typeof(ushort) ||
               type == typeof(int) || type == typeof(uint) ||
               type == typeof(long) || type == typeof(ulong) ||
               type == typeof(float) || type == typeof(double) ||
               type == typeof(decimal);
    }

    public static bool IsNullOrEmpty(this int? number)
        => !number.HasValue || number.Value.IsEmpty();

    public static bool IsNullOrEmpty(this long? number)
        => !number.HasValue || number.Value.IsEmpty();

    public static bool IsNotNullOrEmpty(this int? number)
        => number.HasValue && number.Value.IsNotEmpty();

    public static bool IsNotNullOrEmpty(this long? number)
        => number.HasValue && number.Value.IsNotEmpty();

    public static bool IsEmpty(this int number)
        => number <= 0;

    public static bool IsEmpty(this long number)
        => number <= 0;

    public static bool IsNotEmpty(this int number)
        => number > 0;

    public static bool IsNotEmpty(this long number)
        => number > 0;
}