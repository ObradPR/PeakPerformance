using System.ComponentModel;
using System.Reflection;

namespace PeakPerformance.Common.Extensions;

public static partial class Extensions
{
    public static string[] GetStringValues<T>(params T[] enumList)
       where T : struct, Enum
        => enumList.Select(_ => _.ToString()).ToArray();

    public static T[] GetValues<T>()
        where T : struct, Enum
        => (T[])Enum.GetValues(typeof(T));

    public static string[] GetNames<T>()
        where T : struct, Enum
        => Enum.GetNames(typeof(T));

    public static string[] GetNames<T>(this IEnumerable<int> enums) where T : struct, Enum
        => enums.Any() ? enums.Select(_ => ((T)(object)_).ToString()).ToArray() : [];

    public static string GetDescription<T>(this T value)
        where T : struct, Enum
    {
        FieldInfo fi = value.GetType().GetField(value.ToString());
        DescriptionAttribute[] attributes = fi?.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[] ?? [];
        return attributes.Length > 0 ? attributes[0].Description : value.ToString();
    }

    public static T Parse<T>(this string value)
        where T : struct, Enum
        => (T)Enum.Parse(typeof(T), value, true);

    public static bool TryParse<T>(this string value, out T result)
        where T : struct, Enum
        => Enum.TryParse(value, true, out result);

    public static bool IsDefined<T>(this T value)
        where T : struct, Enum
        => Enum.IsDefined(typeof(T), value);

    public static List<T> ParseList<T>(this IEnumerable<string> values)
        where T : struct, Enum
    {
        return values
            .Where(_ => _.TryParse(out T _))
            .Select(_ => _.Parse<T>())
            .Cast<T>()
            .ToList();
    }

    public static IEnumerable<(int Id, string Description)> GetValuesAndDescriptions<T>()
        where T : struct, Enum
    {
        return Enum.GetValues(typeof(T))
            .Cast<T>()
            .Select(_ => (Convert.ToInt32(_), _.GetDescription()));
    }
}