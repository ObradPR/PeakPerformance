namespace PeakPerformance.Persistence.Extensions;

public static partial class Extensions
{
    // private

    private static IQueryable<TEntity> IncludeConvert<TEntity>(this IQueryable<TEntity> query, Expression<Func<TEntity, object>> includeProperty)
        where TEntity : class
        => TryParsePath(includeProperty.Body, out var path)
        ? query.Include(path)
        : throw new ArgumentException($"Invalid include parameter: {includeProperty}");

    public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, IEnumerable<SortingOptions> options)
    {
        // assert not null or emptu otpions
        if (options.IsNullOrEmpty())
            throw new ArgumentException($"Invalid sorting of {typeof(T).Name}.");

        var firstOption = options.First();
        var order = GetDynamicOrder<T>(firstOption);

        var orderedQuery = AddOrder(query, orderBy: order, desc: firstOption.Desc);

        foreach (var option in options.Skip(1))
        {
            var thenBy = GetDynamicOrder<T>(option);
            orderedQuery = AddThenOrder(orderedQuery, orderBy: thenBy, desc: option.Desc);
        }

        return (IQueryable<T>)orderedQuery;
    }

    private static dynamic GetDynamicOrder<T>(SortingOptions sorting)
    {
        var entity = Expression.Parameter(typeof(T));
        var property = GetOrderByProperty<T>(entity, sorting.Field);
        var funcType = typeof(Func<,>).MakeGenericType(typeof(T), property.Type);

        dynamic lambda = Expression.Lambda(delegateType: funcType, body: property, parameters: entity);

        return lambda;
    }

    private static MemberExpression GetOrderByProperty<T>(Expression entity, string field)
    {
        var parts = field.Split('.');
        var propertyInfo = typeof(T).GetProperty(parts.First());
        var property = Expression.PropertyOrField(entity, parts.First());

        foreach (var part in parts.Skip(1))
        {
            if (propertyInfo == null)
                throw new ArgumentException($"Invalid sorting option - {field}.");

            if (typeof(BaseDomain).IsAssignableFrom(propertyInfo.PropertyType))
            {
                if (propertyInfo.PropertyType.GetProperty(part) != null)
                {
                    property = Expression.PropertyOrField(property, part);
                    propertyInfo = propertyInfo.PropertyType.GetProperty(part);
                }
                else
                    throw new ArgumentException($"Invalid sorting option - {field}.");
            }
        }

        return property;
    }

    private static IOrderedQueryable<TEntity> AddOrder<TEntity, TProperty>(IQueryable<TEntity> query, Expression<Func<TEntity, TProperty>> orderBy, bool desc = false) =>
        desc ? query.OrderByDescending(orderBy) : query.OrderBy(orderBy);

    private static IOrderedQueryable<TEntity> AddThenOrder<TEntity, TProperty>(IOrderedQueryable<TEntity> query, Expression<Func<TEntity, TProperty>> orderBy, bool desc = false) =>
        desc ? query.ThenByDescending(orderBy) : query.ThenBy(orderBy);
}