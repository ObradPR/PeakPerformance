namespace PeakPerformance.Domain.Entities._Base;

public abstract class BaseIndexDomain<T, TKey> : BaseDomain<TKey>
    where TKey : struct
    where T : BaseIndexDomain<T, TKey>
{
    private static readonly Lazy<string> _tableName = new(Extensions.Extensions.GetFullTableName<T>);

    public static string TableName => _tableName.Value;

    protected class DatabaseIndex(string indexName) : Domain.DatabaseIndex(indexName, TableName)
    { }
}