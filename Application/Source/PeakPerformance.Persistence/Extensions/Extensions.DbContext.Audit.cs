namespace PeakPerformance.Persistence.Extensions;

public static partial class Extensions
{
    public static string GetAuditTriggerName<TEntity>()
        where TEntity : BaseDomain
        => $"trg_{GetTableName<TEntity>(eTableType.Audit)}";

    [Obsolete("Since migration will not be reverted")]
    public static string DropAuditTrigger<TEntity>()
        where TEntity : BaseDomain
        => $"DROP TRIGGER IF EXISTS {GetAuditTriggerName<TEntity>()}";

    [Obsolete("Configuration moved inside entities directly, with relationships configured via data annotations.")]
    public static void ConfigureAuditRelationship<TAudit>(this EntityTypeBuilder<TAudit> builder)
            where TAudit : AuditDomain
    {
        // Get the collection navigation property for the ActionType
        var actionTypeCollectionProperty = typeof(ActionType).GetProperties()
            .FirstOrDefault(_ => _.PropertyType.IsGenericType &&
                                 _.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>) &&
                                 _.PropertyType.GetGenericArguments()[0] == typeof(TAudit));

        if (actionTypeCollectionProperty != null)
        {
            var withManyMethod = typeof(EntityTypeBuilder<TAudit>).GetMethod("WithMany", [typeof(string)]);
            var hasForeignKeyMethod = typeof(EntityTypeBuilder<TAudit>).GetMethod("HasForeignKey", [typeof(string)]);

            if (withManyMethod != null && hasForeignKeyMethod != null)
            {
                var withManyCall = withManyMethod.Invoke(builder.HasOne<ActionType>("ActionType"), [actionTypeCollectionProperty.Name]);
                hasForeignKeyMethod.Invoke(withManyCall, ["ActionTypeId"]);
            }
        }
    }
}