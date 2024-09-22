using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Migrations;
using PeakPerformance.Common.Enums;
using PeakPerformance.Common.Extensions;
using PeakPerformance.Domain.Entities._Base;
using PeakPerformance.Persistence.Enums;
using System.Data;
using System.Reflection;

namespace PeakPerformance.Persistence.Extensions;

public static partial class Extensions
{
    // Connection String
    private static string ConnectionString => "Data Source = localhost; Initial Catalog = PeakPerformance; TrustServerCertificate = True; Integrated security = True;";

    // Predicates

    private static readonly Func<PropertyInfo, bool> excludeAuditProperties = prop =>
        prop.Name != nameof(Audit.AuditId) &&
        prop.Name != nameof(Audit.DetailsJson) &&
        prop.Name != nameof(Audit.ActionTypeId) &&
        prop.Name != nameof(Audit.ActionType);

    // Methods

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

        var columns = GetAuditColumnsOrValues<TAuditTable>();
        var insertValues = GetAuditColumnsOrValues<TAuditTable>("i");
        var deleteValues = GetAuditColumnsOrValues<TAuditTable>("d");

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
                                        THEN {(int)eActionType.Deactivate}
                                    ELSE {(int)eActionType.Update}
                                END
                            ELSE {(int)eActionType.Create}
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
                        {(int)eActionType.Delete},
                        (SELECT CAST((SELECT * FROM deleted d FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) AS NVARCHAR(MAX)))
                    FROM deleted d;
                END
            END
            GO
        ");
    }

    private static string GetAuditColumnsOrValues<TAuditTable>(string prefix = "")
        where TAuditTable : class
    {
        var properties = typeof(TAuditTable).GetProperties()
            .Where(excludeAuditProperties)
            .Select(_ => prefix.IsNullOrEmpty()
                ? _.Name
                : $"{prefix}.{_.Name}");

        return properties.Join(",");
    }

    private static void ReadAndExecuteQuery(this MigrationBuilder migrationBuilder, string sqlFile)
        => migrationBuilder.Sql(File.ReadAllText(sqlFile));

    public static void CreateTableValuedParameterType(this MigrationBuilder migrationBuilder, string name)
    {
        var sqlFile = Path.Combine("Scripts", "Types", "Table", $"{name}.sql");

        migrationBuilder.ReadAndExecuteQuery(sqlFile);
    }

    public static void CreateStoreProcedure(this MigrationBuilder migrationBuilder, string name)
    {
        var sqlFile = Path.Combine("Scripts", "StoreProcedures", $"{name}.sql");

        migrationBuilder.ReadAndExecuteQuery(sqlFile);
    }

    public static void SeedLookupTable<TEntity, TEnum>()
        where TEntity : Entity_lu
        where TEnum : struct, Enum
    {
        var tableName = typeof(TEntity).Name.ToPlural() + "_lu";

        var dataTable = new DataTable();
        dataTable.Columns.Add("Id", typeof(int));
        dataTable.Columns.Add("Name", typeof(string));

        foreach (var (id, name) in Common.Extensions.Extensions.GetValuesAndDescriptions<TEnum>())
            dataTable.Rows.Add(id, name);

        using (var connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            connection.SetIdentityInsert<TEntity>();

            using (var command = new SqlCommand("EXEC [dbo].[usp_SeedLookupTables] @TableName, @IdAndDescriptions", connection))
            {
                command.Parameters.AddWithValue("@TableName", tableName);

                var param = new SqlParameter
                {
                    ParameterName = "@IdAndDescriptions",
                    SqlDbType = SqlDbType.Structured,
                    TypeName = "[dbo].[IdAndDescriptionsType]",
                    Value = dataTable
                };

                command.Parameters.Add(param);
                command.ExecuteNonQuery();
            }

            connection.SetIdentityInsert<TEntity>(eIdentitySwitch.Off);
        }
    }
}