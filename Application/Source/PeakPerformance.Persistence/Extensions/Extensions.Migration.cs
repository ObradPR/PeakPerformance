using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Migrations;
using PeakPerformance.Common.Enums;
using PeakPerformance.Common.Extensions;
using PeakPerformance.Domain.Entities._Base;
using PeakPerformance.Persistence.Enums;
using System.ComponentModel.DataAnnotations.Schema;
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

    public static string GetTableName<TEntity>(eTableType type = eTableType.Normal)
        where TEntity : _BaseEntity
    {
        var name = typeof(TEntity).Name;
        var auditSufix = eTableType.Audit.GetDescription();
        var lookupSufix = eTableType.Lookup.GetDescription();

        if (name.EndsWith(auditSufix))
        {
            name = name.Replace(auditSufix, string.Empty);
        }
        else if (name.EndsWith(lookupSufix))
        {
            name = name.Replace(lookupSufix, string.Empty);
        }

        var plural = Activator.CreateInstance<TEntity>().ShouldPluralize;

        if (plural)
            name = name.ToPlural();

        return type switch
        {
            eTableType.Normal => name,
            eTableType.Audit => name + auditSufix,
            eTableType.Lookup => name + lookupSufix,
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
}