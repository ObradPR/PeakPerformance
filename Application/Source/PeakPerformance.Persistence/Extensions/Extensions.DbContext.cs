using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeakPerformance.Common.Extensions;
using PeakPerformance.Domain.Entities._Base;
using PeakPerformance.Domain.Entities.Application_lu;
using PeakPerformance.Persistence.Enums;

namespace PeakPerformance.Persistence.Extensions;

public static partial class Extensions
{
    public static void ExecuteSqlRaw<TContext>(this TContext context, string sql)
        where TContext : DbContext
        => context.Database.ExecuteSql($"{sql}");

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

    public static string GetAuditTriggerName<TEntity>()
        => $"trg_{typeof(TEntity).Name.ToPlural()}_aud";

    public static string DropAuditTrigger<TEntity>()
        where TEntity : AuditableEntity
        => $"DROP TRIGGER IF EXISTS {GetAuditTriggerName<TEntity>()}";

    public static string GetNullFilterForProperty<T>(this string propertyName)
    {
        var property = typeof(T).GetProperty(propertyName);

        return property is null
            ? throw new ArgumentException($"Property '{propertyName}' not found on type '{typeof(T).Name}'")
            : $"[{property.Name}] IS NOT NULL";
    }

    public static void ConfigureAuditRelationship<T>(this EntityTypeBuilder<T> builder)
            where T : Audit
    {
        // Get the collection navigation property for the ActionType
        var actionTypeCollectionProperty = typeof(ActionType).GetProperties()
            .FirstOrDefault(_ => _.PropertyType.IsGenericType &&
                                 _.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>) &&
                                 _.PropertyType.GetGenericArguments()[0] == typeof(T));

        if (actionTypeCollectionProperty is not null)
        {
            var withManyMethod = typeof(EntityTypeBuilder<T>).GetMethod("WithMany", [typeof(string)]);
            var hasForeignKeyMethod = typeof(EntityTypeBuilder<T>).GetMethod("HasForeignKey", [typeof(string)]);

            if (withManyMethod is not null && hasForeignKeyMethod is not null)
            {
                var withManyCall = withManyMethod.Invoke(builder.HasOne<ActionType>("ActionType"), [actionTypeCollectionProperty.Name]);
                hasForeignKeyMethod.Invoke(withManyCall, ["ActionTypeId"]);
            }
        }
    }
}