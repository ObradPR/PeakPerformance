using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Diagnostics;

namespace PeakPerformance.Persistence.Contexts;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    { }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer("Data Source = localhost; Initial Catalog = PeakPerformance; TrustServerCertificate = True; Integrated security = True;")
                .LogTo(_ => Debug.WriteLine(_));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        if (!EF.IsDesignTime)
            configurationBuilder.Conventions.Add(_ => new BlankTriggerAddingConvention());
    }

    // conventions

    private class BlankTriggerAddingConvention : IModelFinalizingConvention
    {
        public virtual void ProcessModelFinalizing(
            IConventionModelBuilder modelBuilder,
            IConventionContext<IConventionModelBuilder> context)
        {
            foreach (var entityType in modelBuilder.Metadata.GetEntityTypes())
            {
                var table = StoreObjectIdentifier.Create(entityType, StoreObjectType.Table);

                if (table != null)
                {
                    var auditTriggerName = GetAuditTriggerName(entityType.ClrType);

                    if (entityType.GetDeclaredTriggers().Any(_ => _.GetDatabaseName(table.Value) == auditTriggerName))
                    {
                        entityType.Builder.HasTrigger(auditTriggerName);
                    }
                }
            }
        }

        private static string GetAuditTriggerName(Type entityType)
        {
            var method = typeof(Extensions.Extensions)
                .GetMethod(nameof(Extensions.Extensions.GetAuditTriggerName))!
                .MakeGenericMethod(entityType);

            return (string)method.Invoke(null, null)!;
        }
    }
}