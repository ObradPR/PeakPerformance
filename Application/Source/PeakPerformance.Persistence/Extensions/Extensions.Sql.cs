namespace PeakPerformance.Persistence.Extensions;

public static partial class Extensions
{
    public static void SetIdentityInsert<TEntity>(this SqlConnection connection, eIdentitySwitch identitySwitch = eIdentitySwitch.On, string schema = "dbo")
        where TEntity : BaseDomain
    {
        var tableName = GetTableName<TEntity>(eTableType.Lookup);

        var sqlSwitch = identitySwitch switch
        {
            eIdentitySwitch.On => eIdentitySwitch.On.GetDescription(),
            eIdentitySwitch.Off => eIdentitySwitch.Off.GetDescription(),
            _ => throw new ArgumentException("Invalid identity switch value.", nameof(identitySwitch)),
        };

        var sql = $"SET IDENTITY_INSERT [{schema}].[{tableName}] {sqlSwitch};";

        using (var command = new SqlCommand(sql, connection))
        {
            command.ExecuteNonQuery();
        }
    }

    public static string GetNullFilterForProperty<T>(this string propertyName)
    {
        var property = typeof(T).GetProperty(propertyName);

        return property == null
            ? throw new ArgumentException($"Property '{propertyName}' not found on type '{typeof(T).Name}'")
            : $"[{property.Name}] IS NOT NULL";
    }

    private static bool CheckIdentity<TEntity>(this SqlConnection connection, eTableType tableType, string columnName = "Id")
       where TEntity : BaseDomain
    {
        var tableName = GetTableName<TEntity>(tableType);

        var query = $@"
            SELECT COLUMNPROPERTY(OBJECT_ID(TABLE_SCHEMA + '.' + TABLE_NAME), COLUMN_NAME, 'IsIdentity') AS IsIdentity
            FROM INFORMATION_SCHEMA.COLUMNS
            WHERE TABLE_NAME = '{tableName}' AND COLUMN_NAME = '{columnName}'";

        using (var command = new SqlCommand(query, connection))
        {
            var result = command.ExecuteScalar();
            return result != DBNull.Value && Convert.ToInt32(result) == 1;
        }
    }
}