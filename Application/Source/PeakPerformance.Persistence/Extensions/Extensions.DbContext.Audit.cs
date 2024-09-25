using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeakPerformance.Domain.Entities._Base;
using PeakPerformance.Domain.Entities.Application_lu;
using PeakPerformance.Persistence.Enums;

namespace PeakPerformance.Persistence.Extensions;

public static partial class Extensions
{
    public static string GetAuditTriggerName<TEntity>()
        where TEntity : BaseEntity
        => $"trg_{GetTableName<TEntity>(eTableType.Audit)}";

    [Obsolete("Since migration will not be reverted")]
    public static string DropAuditTrigger<TEntity>()
        where TEntity : AuditableEntity
        => $"DROP TRIGGER IF EXISTS {GetAuditTriggerName<TEntity>()}";

    public static void ConfigureAuditRelationship<T>(this EntityTypeBuilder<T> builder)
            where T : Audit
    {
        // Get the collection navigation property for the ActionType
        var actionTypeCollectionProperty = typeof(ActionType).GetProperties()
            .FirstOrDefault(_ => _.PropertyType.IsGenericType &&
                                 _.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>) &&
                                 _.PropertyType.GetGenericArguments()[0] == typeof(T));

        if (actionTypeCollectionProperty != null)
        {
            var withManyMethod = typeof(EntityTypeBuilder<T>).GetMethod("WithMany", [typeof(string)]);
            var hasForeignKeyMethod = typeof(EntityTypeBuilder<T>).GetMethod("HasForeignKey", [typeof(string)]);

            if (withManyMethod != null && hasForeignKeyMethod != null)
            {
                var withManyCall = withManyMethod.Invoke(builder.HasOne<ActionType>("ActionType"), [actionTypeCollectionProperty.Name]);
                hasForeignKeyMethod.Invoke(withManyCall, ["ActionTypeId"]);
            }
        }
    }
}