using Microsoft.EntityFrameworkCore;
using PeakPerformance.Common.Extensions;
using PeakPerformance.Domain.Entities._Base;
using System.ComponentModel;

namespace PeakPerformance.Persistence.Extensions;

public enum eIdentitySwitch
{
    [Description("ON")]
    On = 1,

    [Description("OFF")]
    Off = 2
}

public static partial class Extensions
{
    public static void ExecuteSqlRaw<TContext>(this TContext context, string sql)
        where TContext : DbContext
        => context.Database.ExecuteSql($"{sql}");

    public static void SetIdentityInsert<TContext, TEntity>(this TContext context, TEntity table, bool lookupTable = true, eIdentitySwitch identitySwitch = eIdentitySwitch.On, string schema = "dbo")
        where TContext : DbContext
        where TEntity : Type
    {
        string tableName = lookupTable ? table.Name.ToPlural() + "_lu" : table.Name.ToPlural();
        string sql = identitySwitch switch
        {
            eIdentitySwitch.On => eIdentitySwitch.On.GetDescription(),
            eIdentitySwitch.Off => eIdentitySwitch.Off.GetDescription(),
            _ => throw new ArgumentException("Invalid identity switch value.", nameof(identitySwitch)),
        };

        context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT {schema}.{tableName} {sql}");
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
}