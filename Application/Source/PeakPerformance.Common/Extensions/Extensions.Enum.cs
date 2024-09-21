using System.ComponentModel;
using System.Reflection;

namespace PeakPerformance.Common.Extensions;

public static partial class Extensions
{
    public static string[] GetStringValuesFromEnums<T>(params T[] enumList)
       where T : struct, Enum
        => enumList.Select(_ => _.ToString()).ToArray();

    public static T[] GetEnumValues<T>()
        where T : struct, Enum
        => (T[])Enum.GetValues(typeof(T));

    public static string[] GetEnumNames<T>()
        where T : struct, Enum
        => Enum.GetNames(typeof(T));

    public static string GetEnumDescription<TEnum>(this TEnum enumValue)
        where TEnum : struct, Enum
    {
        FieldInfo? fi = enumValue.GetType().GetField(enumValue.ToString());
        DescriptionAttribute[] attributes = fi?.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[] ?? [];
        return attributes.Length > 0 ? attributes[0].Description : enumValue.ToString();
    }

    public static T ParseEnum<T>(this string value)
        where T : struct, Enum
        => (T)Enum.Parse(typeof(T), value, true);

    public static bool TryParseEnum<T>(this string value, out T result)
        where T : struct, Enum
        => Enum.TryParse(value, true, out result);

    public static bool IsDefined<T>(this T value)
        where T : struct, Enum
        => Enum.IsDefined(typeof(T), value);

    public static List<T> ParseEnumList<T>(this IEnumerable<string> values)
        where T : struct, Enum
    {
        return values
            .Where(_ => _.TryParseEnum(out T _))
            .Select(_ => _.ParseEnum<T>())
            .Cast<T>()
            .ToList();
    }
}