﻿using Microsoft.EntityFrameworkCore.Migrations;
using PeakPerformance.Common.Enums;
using PeakPerformance.Domain.Entities._Base;
using PeakPerformance.Persistence.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace PeakPerformance.Persistence.Extensions;

public static partial class Extensions
{
    // Predicates

    private static readonly Func<PropertyInfo, bool> excludeAuditProperties = prop =>
        prop.Name != nameof(Audit.AuditId) &&
        prop.Name != nameof(Audit.DetailsJson) &&
        prop.Name != nameof(Audit.ActionTypeId) &&
        prop.Name != nameof(Audit.ActionType) &&
        !Attribute.IsDefined(prop, typeof(NotMappedAttribute));

    // Methods

    public static void CreateAuditTriggersForTable<TAudit, TEntity>(this MigrationBuilder migrationBuilder)
        where TAudit : Audit
        where TEntity : _BaseEntity
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

    private static string GetAuditColumnsOrValues<TAudit>(string prefix = "")
        where TAudit : class
    {
        var properties = typeof(TAudit).GetProperties()
            .Where(excludeAuditProperties)
            .Select(_ => prefix.IsNullOrEmpty()
                ? _.Name
                : $"{prefix}.{_.Name}");

        return properties.Join(",");
    }
}