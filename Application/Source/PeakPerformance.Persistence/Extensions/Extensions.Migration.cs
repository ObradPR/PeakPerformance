using Microsoft.EntityFrameworkCore.Migrations;
using PeakPerformance.Common.Extensions;
using PeakPerformance.Domain.Entities._Base;

namespace PeakPerformance.Persistence.Extensions;

public static partial class Extensions
{
    public static void CreateAuditTriggersForTable<TAuditTable, TEntity>(this MigrationBuilder migrationBuilder)
        where TAuditTable : Audit
        where TEntity : class
    {
        var triggerName = GetAuditTriggerName<TEntity>();
        var tableName = typeof(TEntity).Name.ToPlural();
        var auditTableName = typeof(TEntity).Name.ToPlural() + "_aud";

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
                    INSERT INTO {auditTableName} ({columns}, DetailsJson)
                    SELECT
                        {insertValues},
                        (SELECT CAST((SELECT * FROM inserted i FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) AS NVARCHAR(MAX)))
                    FROM inserted i;
                END
                ELSE IF EXISTS (SELECT * FROM deleted)
                BEGIN
                    -- Handle DELETE
                    INSERT INTO {auditTableName} ({columns}, DetailsJson)
                    SELECT
                        {deleteValues},
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
            .Where(_ => _.Name != nameof(Audit.AuditId) && _.Name != nameof(Audit.DetailsJson))
            .Select(_ => $"i.{_.Name}");

        return string.Join(",", properties);
    }

    private static string GetDeleteValues<TAuditTable>()
        where TAuditTable : Audit
    {
        var properties = typeof(TAuditTable).GetProperties()
            .Where(_ => _.Name != nameof(Audit.AuditId) && _.Name != nameof(Audit.DetailsJson))
            .Select(_ => $"d.{_.Name}");
        return string.Join(",", properties);
    }

    private static string GetAuditColumns<TAuditTable>()
        where TAuditTable : Audit
    {
        var properties = typeof(TAuditTable).GetProperties()
            .Where(_ => _.Name != nameof(Audit.AuditId) && _.Name != nameof(Audit.DetailsJson))
            .Select(_ => _.Name);

        return string.Join(",", properties);
    }
}