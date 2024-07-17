using System.ComponentModel;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;

namespace PeakPerformance.Common.Extensions;

public static partial class Extensions
{
    public static string AppendArgument(this string value, string argument) => string.Format(value, argument);

    public static string AppendArgument(this string value, params string[] args) => string.Format(value, args);

    public static bool IsNullOrEmpty(this string value)
        => string.IsNullOrEmpty(value);

    public static bool IsNullOrWhiteSpace(this string value)
        => string.IsNullOrWhiteSpace(value);

    public static string? ToTitleCase(this string value)
        =>
        value is null
        ? null
        : CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());

    public static bool ContainsIgnoreCase(this string source, string toCheck)
        => source?.IndexOf(toCheck, StringComparison.OrdinalIgnoreCase) >= 0;

    public static string Truncate(this string value, int maxLength)
        =>
        value.IsNullOrEmpty()
        ? value
        : (value.Length <= maxLength ? value : value.Substring(0, maxLength));

    public static string? Reverse(this string value)
    {
        if (value is null)
            return null;

        char[] array = value.ToCharArray();
        Array.Reverse(array);
        return new string(array);
    }

    public static string? RemoveWhitespace(this string value)
        =>
        value is null
        ? null
        : new string(value.Where(c => !char.IsWhiteSpace(c)).ToArray());

    public static string ToCamelCase(this string value)
        =>
        value.IsNullOrEmpty()
        ? value
        : char.ToLowerInvariant(value[0]) + value.Substring(1);

    public static string FormatWith(this string value, params object[] args)
        => string.Format(value, args);

    public static string GetUserFullName(string firstName, string lastName, string? middleName)
        => string.Join(" ", firstName, middleName, lastName);

    public static bool IsNumeric(this string value)
        => int.TryParse(value, out _);

    public static string ToPlural(this string singular)
    {
        if (singular.EndsWith("y"))
            return singular.Truncate(singular.Length - 1) + "ies";

        if (Regex.IsMatch(singular, "(s|ss|sh|ch|x|z)$"))
            return singular + "es";

        return singular + "s";
    }

    public static string GetPropertyDescription<T>(Expression<Func<T, object>> propertyExpression)
    {
        MemberExpression memberExpression;

        // Check if the expression is Unary (boxing value types like DateTime)
        if (propertyExpression.Body is UnaryExpression unaryExpression && unaryExpression.Operand is MemberExpression unaryMember)
        {
            memberExpression = unaryMember;
        }
        else if (propertyExpression.Body is MemberExpression member)
        {
            memberExpression = member;
        }
        else
        {
            throw new ArgumentException("Expression is not a member access expression.", nameof(propertyExpression));
        }

        var propertyInfo = (PropertyInfo)memberExpression.Member;
        var descriptionAttribute = propertyInfo.GetCustomAttribute<DescriptionAttribute>();

        return descriptionAttribute?.Description ?? propertyInfo.Name;
    }

    public static int ToInt(this string value)
        => int.Parse(value);
}