namespace PeakPerformance.Domain.Entities._Base.Audit;

public abstract class AuditIndexDomain<T, TKey> : AuditDomain<TKey>
    where TKey : struct
    where T : AuditIndexDomain<T, TKey>
{
    private static readonly Lazy<string> _tableName = new(Extensions.Extensions.GetFullTableName<T>);

    public static string TableName => _tableName.Value;

    protected class DatabaseIndex(string indexName) : Domain.DatabaseIndex(indexName, TableName)
    { }
}