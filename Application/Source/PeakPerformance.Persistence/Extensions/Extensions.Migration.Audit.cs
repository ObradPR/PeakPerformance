namespace PeakPerformance.Persistence.Extensions;

public static partial class Extensions
{
    // predicates

    private static readonly Func<PropertyInfo, bool> excludeAuditProperties = prop =>
        prop.Name != nameof(AuditDomain<object>.AuditId) &&
        prop.Name != nameof(AuditDomain<object>.DetailsJson) &&
        prop.Name != nameof(AuditDomain<object>.ActionTypeId) &&
        prop.Name != nameof(AuditDomain<object>.ActionType) &&
        !Attribute.IsDefined(prop, typeof(NotMappedAttribute));

    // methods

    public static void CreateAuditTriggersForTable<TAudit, TEntity>(this MigrationBuilder migrationBuilder)
        where TAudit : AuditDomain
        where TEntity : BaseDomain
    {
        var triggerName = GetAuditTriggerName<TEntity>();

        var tableName = GetTableName<TEntity>();
        var auditTableName = GetTableName<TEntity>(eTableType.Audit);

        var columns = GetAuditColumnsOrValues<TAudit>();
        var insertValues = GetAuditColumnsOrValues<TAudit>("i");
        var deleteValues = GetAuditColumnsOrValues<TAudit>("d");

        migrationBuilder.Sql($@"
            EXEC [dbo].[usp_CreateAuditTrigger]
                @TriggerName = N'{triggerName}',
                @TableName = N'{tableName}',
                @AuditTableName = N'{auditTableName}',
                @Columns = N'{columns}',
                @InsertValues = N'{insertValues}',
                @DeleteValues = N'{deleteValues}',
                @CreateAction = {(int)eActionType.Create},
                @UpdateAction = {(int)eActionType.Update},
                @DeleteAction = {(int)eActionType.Delete},
                @DeactivateAction = {(int)eActionType.Deactivate}
        ");
    }

    // private

    private static string GetAuditColumnsOrValues<TAudit>(string prefix = "")
        where TAudit : AuditDomain
    {
        var properties = typeof(TAudit).GetProperties()
            .Where(excludeAuditProperties)
            .Select(_ => prefix.IsNullOrEmpty()
                ? _.Name
                : $"{prefix}.{_.Name}");

        return properties.Join(", ");
    }
}