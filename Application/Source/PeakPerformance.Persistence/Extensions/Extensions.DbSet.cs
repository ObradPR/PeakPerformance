namespace PeakPerformance.Persistence.Extensions;

public static partial class Extensions
{
    public static async Task<TEntity> GetSingleAsync<TEntity>(this DbSet<TEntity> dbSet, params object[] keyValue)
        where TEntity : class
        => await dbSet.FindAsync(keyValue);

    public static async Task<TEntity> GetSingleAsync<TEntity>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        where TEntity : class
    {
        if (includeProperties == null)
            return await dbSet.FirstOrDefaultAsync(predicate);

        var query = includeProperties.Aggregate(dbSet.AsQueryable(), (current, property) => current.IncludeConvert(property));

        return await query.FirstOrDefaultAsync(predicate);
    }

    public static async Task<TEntity> GetSingleNoTrackingAsync<TEntity>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
       where TEntity : class
    {
        if (includeProperties == null)
            return await dbSet.FirstOrDefaultAsync(predicate);

        var query = includeProperties.Aggregate(dbSet.AsQueryable(), (current, property) => current.IncludeConvert(property));

        return await query.AsNoTracking().FirstOrDefaultAsync(predicate);
    }

    public static async Task<TEntity> GetSingleAsSplitQueryAsync<TEntity>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        where TEntity : class
    {
        if (includeProperties == null)
            return await dbSet.FirstOrDefaultAsync(predicate);

        var query = includeProperties.Aggregate(dbSet.AsQueryable(), (current, property) => current.IncludeConvert(property));

        return await query.AsSplitQuery().FirstOrDefaultAsync(predicate);
    }

    public static async Task<TEntity> GetSingleAsSplitQueryNoTrackingAsync<TEntity>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        where TEntity : class
    {
        if (includeProperties == null)
            return await dbSet.FirstOrDefaultAsync(predicate);

        var query = includeProperties.Aggregate(dbSet.AsQueryable(), (current, property) => current.IncludeConvert(property));

        return await query.AsSplitQuery().AsNoTracking().FirstOrDefaultAsync(predicate);
    }

    public static async Task<TEntity> GetSingleOrDefaultAsync<TEntity>(this DbSet<TEntity> dbSet, IBaseDomain<long> data, params Expression<Func<TEntity, object>>[] includeProperties)
        where TEntity : BaseDomain<long>, new()
        => data.Id == 0
        ? new()
        : await dbSet.GetSingleAsync(_ => _.Id == data.Id, includeProperties);

    public static async Task<List<TEntity>> GetListAsync<TEntity>(this DbSet<TEntity> dbSet, CancellationToken cancellationToken, params Expression<Func<TEntity, object>>[] includeProperties)
        where TEntity : class
        => await dbSet.GetQueryable(_ => true, 0, includeProperties).ToListAsync(cancellationToken);

    public static async Task<List<TEntity>> GetListAsync<TEntity>(this DbSet<TEntity> dbSet, params Expression<Func<TEntity, object>>[] includeProperties)
        where TEntity : class
        => await dbSet.GetQueryable(_ => true, 0, includeProperties).ToListAsync();

    public static async Task<List<TEntity>> GetListAsync<TEntity>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        where TEntity : class
        => await dbSet.GetQueryable(predicate, 0, includeProperties).ToListAsync();

    public static async Task<List<TEntity>> GetListAsSplitQueryAsync<TEntity>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        where TEntity : class
        => await dbSet.GetQueryable(predicate, 0, includeProperties).AsSplitQuery().ToListAsync();

    public static async Task<List<TEntity>> GetListAsync<TEntity>(this DbSet<TEntity> dbSet, CancellationToken cancellationToken, List<Expression<Func<TEntity, bool>>> predicates, params Expression<Func<TEntity, object>>[] includeProperties)
        where TEntity : class
        => await dbSet.GetQueryable(predicates, includeProperties).ToListAsync(cancellationToken);

    public static async Task<List<TEntity>> GetListAsync<TEntity>(this DbSet<TEntity> dbSet, List<Expression<Func<TEntity, bool>>> predicates, params Expression<Func<TEntity, object>>[] includeProperties)
        where TEntity : class
        => await dbSet.GetQueryable(predicates, includeProperties).ToListAsync();

    public static async Task<List<TEntity>> GetListAsync<TProperty, TEntity>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TProperty>> orderBy, bool desc = false, params Expression<Func<TEntity, object>>[] includeProperties)
        where TEntity : class
        => await dbSet.GetQueryable(predicate, orderBy, 0, 0, desc, includeProperties).ToListAsync();

    public static async Task<List<TEntity>> GetListAsync<TProperty, TEntity>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TProperty>> orderBy, int skip, int take, bool desc = false, params Expression<Func<TEntity, object>>[] includeProperties)
        where TEntity : class
        => await dbSet.GetQueryable(predicate, orderBy, skip, take, desc, includeProperties).ToListAsync();

    public static async Task<List<TEntity>> GetListNoTrackingAsync<TEntity>(this DbSet<TEntity> dbSet, CancellationToken cancellationToken, params Expression<Func<TEntity, object>>[] includeProperties)
        where TEntity : class
        => await dbSet.GetQueryable(_ => true, 0, includeProperties).AsNoTracking().ToListAsync(cancellationToken);

    public static async Task<List<TEntity>> GetListNoTrackingAsync<TEntity>(this DbSet<TEntity> dbSet, params Expression<Func<TEntity, object>>[] includeProperties)
        where TEntity : class
        => await dbSet.GetQueryable(_ => true, 0, includeProperties).AsNoTracking().ToListAsync();

    public static async Task<List<TEntity>> GetListNoTrackingAsync<TEntity>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        where TEntity : class
        => await dbSet.GetQueryable(predicate, 0, includeProperties).AsNoTracking().ToListAsync();

    public static async Task<List<TEntity>> GetListAsSplitQueryNoTrackingAsync<TEntity>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        where TEntity : class
        => await dbSet.GetQueryable(predicate, 0, includeProperties).AsSplitQuery().AsNoTracking().ToListAsync();

    public static async Task<List<TEntity>> GetListNoTrackingAsync<TEntity>(this DbSet<TEntity> dbSet, CancellationToken cancellationToken, List<Expression<Func<TEntity, bool>>> predicates, params Expression<Func<TEntity, object>>[] includeProperties)
        where TEntity : class
        => await dbSet.GetQueryable(predicates, includeProperties).AsNoTracking().ToListAsync(cancellationToken);

    public static async Task<List<TEntity>> GetListNoTrackingAsync<TEntity>(this DbSet<TEntity> dbSet, List<Expression<Func<TEntity, bool>>> predicates, params Expression<Func<TEntity, object>>[] includeProperties)
       where TEntity : class
       => await dbSet.GetQueryable(predicates, includeProperties).AsNoTracking().ToListAsync();

    public static async Task<List<TEntity>> GetListNoTrackingAsync<TProperty, TEntity>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TProperty>> orderBy, bool desc = false, params Expression<Func<TEntity, object>>[] includeProperties)
        where TEntity : class
        => await dbSet.GetQueryable(predicate, orderBy, 0, 0, desc, includeProperties).AsNoTracking().ToListAsync();

    public static async Task<List<TEntity>> GetListNoTrackingAsync<TProperty, TEntity>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TProperty>> orderBy, int skip, int take, bool desc = false, params Expression<Func<TEntity, object>>[] includeProperties)
        where TEntity : class
        => await dbSet.GetQueryable(predicate, orderBy, skip, take, desc, includeProperties).AsNoTracking().ToListAsync();

    public static async Task<List<TResult>> GetSelectAsync<TResult, TEntity>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> select, params Expression<Func<TEntity, object>>[] includeProperties)
        where TEntity : class
        => await dbSet.GetQueryable(predicate, select, includeProperties).ToListAsync();

    public static async Task<long> CountAsync<TEntity>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        where TEntity : class
        => await dbSet.GetQueryable(predicate, 0, includeProperties).LongCountAsync();

    public static async Task<PagingResult<TEntity>> SearchAsync<TProperty, TEntity>(this DbSet<TEntity> dbSet, SearchOptions options, Expression<Func<TEntity, TProperty>> defaultOrder, bool desc, List<Expression<Func<TEntity, bool>>> predicates, params Expression<Func<TEntity, object>>[] includeProperties)
        where TEntity : class
        => await dbSet.SearchAsync(default, options, defaultOrder, desc, _ => _, predicates, includeProperties);

    public static async Task<PagingResult<TEntity>> SearchAsync<TProperty, TEntity>(this DbSet<TEntity> dbSet, CancellationToken cancellationToken, SearchOptions options, Expression<Func<TEntity, TProperty>> defaultOrder, bool desc, List<Expression<Func<TEntity, bool>>> predicates, params Expression<Func<TEntity, object>>[] includeProperties)
        where TEntity : class
        => await dbSet.SearchAsync(cancellationToken, options, defaultOrder, desc, _ => _, predicates, includeProperties);

    public static async Task<PagingResult<TResult>> SearchAsync<TResult, TProperty, TEntity>(this DbSet<TEntity> dbSet, SearchOptions options, Expression<Func<TEntity, TProperty>> defaultOrder, bool desc, Expression<Func<TEntity, TResult>> select, List<Expression<Func<TEntity, bool>>> predicates, params Expression<Func<TEntity, object>>[] includeProperties)
        where TEntity : class
        => await dbSet.SearchAsync(default, options, defaultOrder, desc, select, predicates, includeProperties);

    public static async Task<PagingResult<TResult>> SearchAsync<TResult, TProperty, TEntity>(this DbSet<TEntity> dbSet, CancellationToken cancellationToken, SearchOptions options, Expression<Func<TEntity, TProperty>> defaultOrder, bool desc, Expression<Func<TEntity, TResult>> select, List<Expression<Func<TEntity, bool>>> predicates, params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : class
    {
        var query = dbSet.AsQueryable();

        if (predicates != null)
            query = predicates.Aggregate(query, (current, expression) => current.Where(expression));

        var total = options.TotalCount == false ? 0 : await query.CountAsync(cancellationToken);

        if (includeProperties != null)
            query = includeProperties.Aggregate(query, (current, property) => current.IncludeConvert(property));

        query = options.SortingOptions.IsNotNullOrEmpty()
            ? query.OrderBy(options.SortingOptions)
            : desc
            ? query.OrderByDescending(defaultOrder)
            : query.OrderBy(defaultOrder);

        if (options.Take != 0)
            query = query.Skip(options.Skip).Take(options.Take);

        return new PagingResult<TResult>
        {
            Total = total,
            Data = await query.Select(select).ToListAsync(cancellationToken)
        };
    }

    public static async Task<PagingResult<TEntity>> SearchNoTrackingAsync<TProperty, TEntity>(this DbSet<TEntity> dbSet, SearchOptions options, Expression<Func<TEntity, TProperty>> defaultOrder, bool desc, List<Expression<Func<TEntity, bool>>> predicates, params Expression<Func<TEntity, object>>[] includeProperties)
        where TEntity : class
        => await dbSet.SearchNoTrackingAsync(default, options, defaultOrder, desc, _ => _, predicates, includeProperties);

    public static async Task<PagingResult<TEntity>> SearchNoTrackingAsync<TProperty, TEntity>(this DbSet<TEntity> dbSet, CancellationToken cancellationToken, SearchOptions options, Expression<Func<TEntity, TProperty>> defaultOrder, bool desc, List<Expression<Func<TEntity, bool>>> predicates, params Expression<Func<TEntity, object>>[] includeProperties)
        where TEntity : class
        => await dbSet.SearchNoTrackingAsync(cancellationToken, options, defaultOrder, desc, _ => _, predicates, includeProperties);

    public static async Task<PagingResult<TResult>> SearchNoTrackingAsync<TResult, TProperty, TEntity>(this DbSet<TEntity> dbSet, SearchOptions options, Expression<Func<TEntity, TProperty>> defaultOrder, bool desc, Expression<Func<TEntity, TResult>> select, List<Expression<Func<TEntity, bool>>> predicates, params Expression<Func<TEntity, object>>[] includeProperties)
        where TEntity : class
        => await dbSet.SearchNoTrackingAsync(default, options, defaultOrder, desc, select, predicates, includeProperties);

    public static async Task<PagingResult<TResult>> SearchNoTrackingAsync<TResult, TProperty, TEntity>(this DbSet<TEntity> dbSet, CancellationToken cancellationToken, SearchOptions options, Expression<Func<TEntity, TProperty>> defaultOrder, bool desc, Expression<Func<TEntity, TResult>> select, List<Expression<Func<TEntity, bool>>> predicates, params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : class
    {
        var query = dbSet.AsQueryable();
        query = predicates.Aggregate(query, (current, expression) => current.Where(expression));

        var total = options.TotalCount == false ? 0 : await query.CountAsync(cancellationToken);

        if (includeProperties != null)
            query = includeProperties.Aggregate(query, (current, property) => current.IncludeConvert(property));

        query = options.SortingOptions.IsNotNullOrEmpty()
            ? query.OrderBy(options.SortingOptions)
            : desc
            ? query.OrderByDescending(defaultOrder)
            : query.OrderBy(defaultOrder);

        if (options.Take != 0)
            query = query.Skip(options.Skip).Take(options.Take);

        return new PagingResult<TResult>
        {
            Total = total,
            Data = await query.Select(select).ToListAsync(cancellationToken)
        };
    }

    // private

    private static IQueryable<TEntity> GetQueryable<TEntity>(this DbSet<TEntity> dbSet, List<Expression<Func<TEntity, bool>>> predicates, params Expression<Func<TEntity, object>>[] includeProperties)
        where TEntity : class
    {
        var query = dbSet.AsQueryable();
        query = predicates.Aggregate(query, (current, expression) => current.Where(expression));

        if (includeProperties != null)
            query = includeProperties.Aggregate(query, (current, property) => current.IncludeConvert(property));

        return query;
    }

    private static IQueryable<TResult> GetQueryable<TResult, TEntity>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> select, params Expression<Func<TEntity, object>>[] includeProperties)
        where TEntity : class
    {
        var query = dbSet.Where(predicate);

        if (includeProperties != null)
            query = includeProperties.Aggregate(query, (current, property) => current.IncludeConvert(property));

        return query.Select(select);
    }

    private static IQueryable<TEntity> GetQueryable<TEntity>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> predicate, int take, params Expression<Func<TEntity, object>>[] includeProperties)
        where TEntity : class
    {
        var query = dbSet.Where(predicate);

        if (includeProperties != null)
            query = includeProperties.Aggregate(query, (current, property) => current.IncludeConvert(property));

        if (take != 0)
            query = query.Take(take);

        return query;
    }

    private static IQueryable<TEntity> GetQueryable<TProperty, TEntity>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TProperty>> orderBy, int skip, int take, bool desc = false, params Expression<Func<TEntity, object>>[] includeProperties)
        where TEntity : class
    {
        var query = dbSet.Where(predicate);

        if (includeProperties != null)
            query = includeProperties.Aggregate(query, (current, property) => current.IncludeConvert(property));

        query = desc
            ? query.OrderByDescending(orderBy).AsQueryable()
            : query.OrderBy(orderBy).AsQueryable();

        if (skip != 0)
            query = query.Skip(skip);

        if (take != 0)
            query = query.Take(take);

        return query;
    }
}