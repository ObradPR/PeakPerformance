using Microsoft.EntityFrameworkCore;
using PeakPerformance.Common.Extensions;
using PeakPerformance.Domain.Attributes;
using PeakPerformance.Domain.Entities._Base.Interfaces;
using PeakPerformance.Persistence.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

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

            var noPluralAttr = entityType.GetCustomAttribute<NoPluralAttribute>();
            var tableAttr = entityType.GetCustomAttribute<TableAttribute>();
            var lookupAttr = entityType.GetCustomAttribute<LookupAttribute>();

            var tableName = tableAttr != null
                ? tableAttr.Name
                : entityType.Name;

            var isAudit = tableName.EndsWith("_aud", StringComparison.OrdinalIgnoreCase);

            if (isAudit)
                tableName = tableName.Replace(eTableType.Audit.GetDescription(), string.Empty);

            if (noPluralAttr == null)
                tableName = tableName.ToPlural();

            if (isAudit)
                tableName += eTableType.Audit.GetDescription();

            if (lookupAttr != null)
                tableName += eTableType.Lookup.GetDescription();

            builder.Entity(entityType).ToTable(tableName);
        }
    }
}