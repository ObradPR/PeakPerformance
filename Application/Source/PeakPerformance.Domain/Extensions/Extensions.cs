using System.Reflection;

namespace PeakPerformance.Domain.Extensions;

public static class Extensions
{
    public static string GetFullTableName<T>()
        where T : class
    {
        var entityType = typeof(T);

        var nonPluralAttr = entityType.GetCustomAttribute<NoPluralAttribute>();

        return nonPluralAttr != null
            ? entityType.Name
            : entityType.Name.ToPlural();
    }
}