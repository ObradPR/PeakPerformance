﻿namespace PeakPerformance.Persistence.Extensions;

public static partial class Extensions
{
    // methods

    public static void CreateSystemUser(this MigrationBuilder migrationBuilder)
    {
        var sqlFile = Path.Combine("Scripts", "Seed", "_User", "SystemUser.sql");

        migrationBuilder.ReadAndExecuteQuery(sqlFile);
    }

    public static void CreateTableValuedParameterType(this MigrationBuilder migrationBuilder, string name)
    {
        var sqlFile = Path.Combine("Scripts", "Types", "Table", $"{name}.sql");

        migrationBuilder.ReadAndExecuteQuery(sqlFile);
    }

    public static void CreateStoreProcedure(this MigrationBuilder migrationBuilder, string name)
    {
        var sqlFile = Path.Combine("Scripts", "StoreProcedures", $"{name}.sql");

        migrationBuilder.DropStoreProcedure(name);
        migrationBuilder.ReadAndExecuteQuery(sqlFile);
    }

    public static void DropStoreProcedure(this MigrationBuilder migrationBuilder, string name)
        => migrationBuilder.Sql($@"
                                    IF OBJECT_ID('{name}', 'P') IS NOT NULL
                                    BEGIN
                                        DROP PROCEDURE {name};
                                    END
                                    GO
                                ");

    public static void SeedLookupTable<TEntity, TEnum>(this MigrationBuilder migrationBuilder)
        where TEntity : BaseLookupDomain<TEntity, TEnum>
        where TEnum : struct, Enum
    {
        var tableName = GetTableName<TEntity>(eTableType.Lookup);

        var dataTable = new DataTable();
        dataTable.Columns.Add(nameof(SystemRole.Id), typeof(int));
        dataTable.Columns.Add(nameof(SystemRole.Name), typeof(string));

        foreach (var (id, name) in Common.Extensions.Extensions.GetValuesAndDescriptions<TEnum>())
            dataTable.Rows.Add(id, name);

        using (var connection = new SqlConnection(Settings.ConnectionString))
        {
            connection.Open();

            var hasIdentity = connection.CheckIdentity<TEntity>(eTableType.Lookup);

            if (hasIdentity)
                connection.SetIdentityInsert<TEntity>();

            using (var command = new SqlCommand($"EXEC {Settings.usp_SeedLookupTables} @TableName, @IdAndDescriptions", connection))
            {
                command.Parameters.AddWithValue("@TableName", tableName);

                var param = new SqlParameter
                {
                    ParameterName = "@IdAndDescriptions",
                    SqlDbType = SqlDbType.Structured,
                    TypeName = Settings.IdAndDescriptionsType,
                    Value = dataTable
                };

                command.Parameters.Add(param);
                command.ExecuteNonQuery();
            }

            if (hasIdentity)
                connection.SetIdentityInsert<TEntity>(eIdentitySwitch.Off);
        }
    }

    public static string GetTableName<TEntity>(eTableType type = eTableType.Normal)
        where TEntity : BaseDomain
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

        var noPluralAttr = typeof(TEntity).GetCustomAttribute<NoPluralAttribute>();

        if (noPluralAttr == null)
            name = name.ToPlural();

        return type switch
        {
            eTableType.Normal => name,
            eTableType.Audit => name + auditSufix,
            eTableType.Lookup => name + lookupSufix,
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }

    // Indexes
    public static void Up(this MigrationBuilder migrationBuilder, IDatabaseIndex index)
        => migrationBuilder.Sql(index.DropSql + "\n" + index.Sql);

    public static void Down(this MigrationBuilder migrationBuilder, IDatabaseIndex index)
        => migrationBuilder.Sql(index.DropSql);

    public static void Up(this MigrationBuilder migrationBuilder, IEnumerable<IDatabaseIndex> indexes)
        => indexes.ToList().ForEach(_ => migrationBuilder.Sql(_.DropSql + "\n" + _.Sql));

    public static void Down(this MigrationBuilder migrationBuilder, IEnumerable<IDatabaseIndex> indexes)
        => indexes.ToList().ForEach(_ => migrationBuilder.Sql(_.DropSql));

    // private

    private static void ReadAndExecuteQuery(this MigrationBuilder migrationBuilder, string sqlFile)
        => migrationBuilder.Sql(File.ReadAllText(sqlFile));
}