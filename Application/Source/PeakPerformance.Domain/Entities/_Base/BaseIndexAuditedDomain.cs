namespace PeakPerformance.Domain.Entities._Base;

public abstract class BaseIndexAuditedDomain<T, TKey> : BaseAuditedDomain<TKey>
    where TKey : struct
    where T : BaseIndexAuditedDomain<T, TKey>
{
    private static readonly Lazy<string> _tableName = new(Extensions.Extensions.GetFullTableName<T>);

    public static string TableName => _tableName.Value;

    protected class DatabaseIndex(string indexName) : Domain.DatabaseIndex(indexName, TableName)
    { }
}