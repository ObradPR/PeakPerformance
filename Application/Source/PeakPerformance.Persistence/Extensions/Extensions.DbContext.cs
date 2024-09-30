using Microsoft.EntityFrameworkCore;
using PeakPerformance.Common.Extensions;
using PeakPerformance.Persistence.Enums;
using System.Linq.Expressions;

namespace PeakPerformance.Persistence.Extensions;

public static partial class Extensions
{
    public static void ExecuteSqlRaw<TContext>(this TContext context, string sql)
        where TContext : DbContext
        => context.Database.ExecuteSql($"{sql}");

    [Obsolete("Seeding data is done by migration")]
    public static void SetIdentityInsert<TContext, TEntity>(this TContext context, eIdentitySwitch identitySwitch = eIdentitySwitch.On, bool lookupTable = true, string schema = "dbo")
        where TContext : DbContext
        where TEntity : class
    {
        string tableName = lookupTable ? typeof(TEntity).Name.ToPlural() + "_lu" : typeof(TEntity).Name.ToPlural();
        string sql = identitySwitch switch
        {
            eIdentitySwitch.On => eIdentitySwitch.On.GetDescription(),
            eIdentitySwitch.Off => eIdentitySwitch.Off.GetDescription(),
            _ => throw new ArgumentException("Invalid identity switch value.", nameof(identitySwitch)),
        };

        context.Database.ExecuteSql($"SET IDENTITY_INSERT {schema}.{tableName} {sql}");
    }

    public static async Task<bool> DatabaseExistsAsync<TContext>(this TContext context)
        where TContext : DbContext
        => await context.Database.CanConnectAsync();

    public static async Task EnsureDatabaseMigratedAsync<TContext>(this TContext context)
        where TContext : DbContext
        => await context.Database.MigrateAsync();

    public static void DetachAllTrackedChanges<TContext>(this TContext context)
        where TContext : DbContext
        => context.ChangeTracker.Entries().ForEach(_ => _.State = EntityState.Detached);

    public static void Create<TContext, TEntity>(this TContext context, TEntity model)
    where TEntity : class
        where TContext : DbContext
    	=> context.Set<TEntity>().Add(model);

    public static void DeleteSingle<TContext, TEntity>(this TContext context, TEntity model)
        where TEntity : class
        where TContext : DbContext
        => context.Set<TEntity>().Remove(model);

    public static void DeleteSingle<TContext, TEntity>(this TContext context, Expression<Func<TEntity, bool>> filter)
        where TEntity : class
        where TContext : DbContext
    {
        var entity = context.Set<TEntity>().SingleOrDefault(filter)
            ?? throw new ArgumentNullException(typeof(TEntity).Name);

        context.DeleteSingle(entity);
    }

    public static void Remove<TContext, TEntity>(this TContext context, TEntity model)
        where TEntity : class
        where TContext : DbContext
        => context.Set<TEntity>().Remove(model);
}