namespace PeakPerformance.Persistence.Extensions;

public static partial class Extensions
{
    // connection string
    private static string ConnectionString => "Data Source = localhost; Initial Catalog = PeakPerformance; TrustServerCertificate = True; Integrated security = True;";

    // methods

    public static void CreateSystemUser(this MigrationBuilder migrationBuilder)
    {
        var sqlFile = Path.Combine("Scripts", "_User", "SystemUser.sql");

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

        migrationBuilder.ReadAndExecuteQuery(sqlFile);
    }

    public static void SeedLookupTable<TEntity, TEnum>()
        where TEntity : BaseLookupDomain<TEntity, TEnum>
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