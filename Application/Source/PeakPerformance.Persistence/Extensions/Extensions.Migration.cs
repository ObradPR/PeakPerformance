using Microsoft.EntityFrameworkCore.Migrations;
using PeakPerformance.Common.Enums;
using PeakPerformance.Common.Extensions;
using PeakPerformance.Domain.Entities._Base;

namespace PeakPerformance.Persistence.Extensions;

public static partial class Extensions
{
    public static void CreateAuditTriggersForTable<TAuditTable, TEntity>(this MigrationBuilder migrationBuilder, bool plural = true)
        where TAuditTable : Audit
        where TEntity : class
    {
        var triggerName = GetAuditTriggerName<TEntity>(plural);
        var tableName = plural
            ? typeof(TEntity).Name.ToPlural()
            : typeof(TEntity).Name;

        var auditTableName = plural
            ? typeof(TEntity).Name.ToPlural() + "_aud"
            : typeof(TAuditTable).Name;

        var columns = GetAuditColumns<TAuditTable>();
        var insertValues = GetInsertValues<TAuditTable>();
        var deleteValues = GetDeleteValues<TAuditTable>();

        migrationBuilder.Sql($@"
            CREATE TRIGGER {triggerName}
            ON {tableName}
            AFTER INSERT, UPDATE, DELETE
            AS
            BEGIN
                SET NOCOUNT ON;

                IF EXISTS (SELECT * FROM inserted)
                BEGIN
                    -- Handle INSERT and UPDATE
                    INSERT INTO {auditTableName} ({columns}, ActionTypeId, DetailsJson)
                    SELECT
                        {insertValues},
                        CASE
                            WHEN EXISTS (SELECT * FROM deleted) THEN
                                CASE
                                    WHEN i.IsActive = 0 AND d.IsActive = 1
                                        THEN {eActionType.Deactivate.ToInt()}
                                    ELSE {eActionType.Update.ToInt()}
                                END
                            ELSE {eActionType.Create.ToInt()}
                        END,
                        (SELECT CAST((SELECT * FROM inserted i FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) AS NVARCHAR(MAX)))
                    FROM inserted i
                    LEFT JOIN deleted d ON i.Id = d.Id
                    WHERE i.Id IS NOT NULL;
                END
                ELSE IF EXISTS (SELECT * FROM deleted)
                BEGIN
                    -- Handle DELETE
                    INSERT INTO {auditTableName} ({columns}, ActionTypeId, DetailsJson)
                    SELECT
                        {deleteValues},
                        {eActionType.Delete.ToInt()},
                        (SELECT CAST((SELECT * FROM deleted d FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) AS NVARCHAR(MAX)))
                    FROM deleted d;
                END
            END
            GO
        ");
    }

    private static string GetInsertValues<TAuditTable>()
        where TAuditTable : Audit
    {
        var properties = typeof(TAuditTable).GetProperties()
            .Where(_ => _.Name != nameof(Audit.AuditId)
                && _.Name != nameof(Audit.DetailsJson)
                && _.Name != nameof(Audit.ActionTypeId)
                && _.Name != nameof(Audit.ActionType))
            .Select(_ => $"i.{_.Name}");

        return string.Join(",", properties);
    }

    private static string GetDeleteValues<TAuditTable>()
        where TAuditTable : Audit
    {
        var properties = typeof(TAuditTable).GetProperties()
            .Where(_ => _.Name != nameof(Audit.AuditId)
                && _.Name != nameof(Audit.DetailsJson)
                && _.Name != nameof(Audit.ActionTypeId)
                && _.Name != nameof(Audit.ActionType))
            .Select(_ => $"d.{_.Name}");
        return string.Join(",", properties);
    }

    private static string GetAuditColumns<TAuditTable>()
        where TAuditTable : Audit
    {
        var properties = typeof(TAuditTable).GetProperties()
            .Where(_ => _.Name != nameof(Audit.AuditId)
                && _.Name != nameof(Audit.DetailsJson)
                && _.Name != nameof(Audit.ActionTypeId)
                && _.Name != nameof(Audit.ActionType))
            .Select(_ => _.Name);

        return string.Join(",", properties);
    }
}