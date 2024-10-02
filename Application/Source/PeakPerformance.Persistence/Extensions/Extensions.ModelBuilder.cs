namespace PeakPerformance.Persistence.Extensions;

public static partial class Extensions
{
    public static void ApplyEntityConfigurations(this ModelBuilder builder, Assembly assembly)
    {
        var entityTypes = assembly.GetTypes()
            .Where(_ => typeof(IConfigurableEntity).IsAssignableFrom(_) && !_.IsAbstract)
            .ToList();

        foreach (var type in entityTypes)
        {
            var instance = Activator.CreateInstance(type) as IConfigurableEntity;
            instance?.Configure(builder);
        }
    }

    public static void SetTableNames(this ModelBuilder builder)
    {
        foreach (var entity in builder.Model.GetEntityTypes())
        {
            var entityType = entity.ClrType;

            var tableAttr = entityType.GetCustomAttribute<TableAttribute>();
            var noPluralAttr = entityType.GetCustomAttribute<NoPluralAttribute>();
            var lookupAttr = entityType.GetCustomAttribute<LookupAttribute>();
            var auditAttr = entityType.GetCustomAttribute<AuditAttribute>();

            var tableName = tableAttr != null
                ? tableAttr.Name
                : entityType.Name;

            if (auditAttr != null)
                tableName = tableName.Replace(eTableType.Audit.GetDescription(), string.Empty);

            if (noPluralAttr == null)
                tableName = tableName.ToPlural();

            if (auditAttr != null)
                tableName += eTableType.Audit.GetDescription();

            if (lookupAttr != null)
                tableName += eTableType.Lookup.GetDescription();

            builder.Entity(entityType).ToTable(tableName);
        }
    }

    public static void ApplyGlobalSoftDeleteFilter(this ModelBuilder builder)
    {
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            if (typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))
            {
                var method = typeof(Extensions)
                    .GetMethod(nameof(ApplySoftDeleteFilter), BindingFlags.NonPublic | BindingFlags.Static)
                    .MakeGenericMethod(entityType.ClrType);

                method.Invoke(null, [builder]);
            }
        }
    }

    public static void ApplySoftDeleteIndexes(this ModelBuilder builder)
    {
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            if (typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))
            {
                var method = typeof(Extensions)
                    .GetMethod(nameof(CreateSoftDeleteIndex), BindingFlags.NonPublic | BindingFlags.Static)
                    .MakeGenericMethod(entityType.ClrType);

                method.Invoke(null, [builder]);
            }
        }
    }

    // private

    private static void ApplySoftDeleteFilter<TEntity>(ModelBuilder builder)
        where TEntity : class, ISoftDelete
        => builder.Entity<TEntity>().HasQueryFilter(_ => _.IsActive == true);

    private static void CreateSoftDeleteIndex<TEntity>(ModelBuilder builder)
        where TEntity : class, ISoftDelete
        => builder.Entity<TEntity>()
            .HasIndex(_ => _.IsActive)
            .HasFilter($"[{nameof(ISoftDelete.IsActive)}] = 1");
}