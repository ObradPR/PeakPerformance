﻿namespace PeakPerformance.Persistence.Contexts;

public partial class ApplicationDbContext : DbContext
{
    public IIdentityUser CurrentUser { get; private set; }

    public ApplicationDbContext()
    { }

    public ApplicationDbContext(IIdentityUser identityUser) => CurrentUser = identityUser;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IIdentityUser identityUser) : base(options)
    {
        CurrentUser = identityUser;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder
                .UseSqlServer("Data Source = localhost; Initial Catalog = PeakPerformance; TrustServerCertificate = True; Integrated security = True;")
                .LogTo(_ => Debug.WriteLine(_));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("dbo");

        modelBuilder.SetTableNames();
        modelBuilder.ApplyEntityConfigurations(typeof(BaseDomain).Assembly);
        modelBuilder.ApplyGlobalSoftDeleteFilter();

        base.OnModelCreating(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        if (!EF.IsDesignTime)
            configurationBuilder.Conventions.Add(_ => new BlankTriggerAddingConvention());
    }

    //
    // Conventions
    //

    private class BlankTriggerAddingConvention : IModelFinalizingConvention
    {
        public virtual void ProcessModelFinalizing(
            IConventionModelBuilder modelBuilder,
            IConventionContext<IConventionModelBuilder> context)
        {
            foreach (var entityType in modelBuilder.Metadata.GetEntityTypes())
            {
                var table = StoreObjectIdentifier.Create(entityType, StoreObjectType.Table);

                if (table != null && entityType.GetDeclaredTriggers().All(t => t.GetDatabaseName(table.Value) == null))
                {
                    entityType.Builder.HasTrigger(table.Value.Name + "_Trigger");
                }

                foreach (var fragment in entityType.GetMappingFragments(StoreObjectType.Table))
                {
                    if (entityType.GetDeclaredTriggers().All(t => t.GetDatabaseName(fragment.StoreObject) == null))
                    {
                        entityType.Builder.HasTrigger(fragment.StoreObject.Name + "_Trigger");
                    }
                }
            }
        }
    }

    // methods

    public bool HasChanges() => ChangeTracker.HasChanges();

    public void ClearChanges() => ChangeTracker.Clear();

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        if (HasChanges())
        {
            var (now, userId) = GetAuditInfo();

            CreateAndUpdateEntries(now, userId, cancellationToken);
            SoftDeleteEntries(now, userId, cancellationToken);
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    // private

    private void SoftDeleteEntries(DateTime now, long userId, CancellationToken cancellationToken = default)
    {
        var softDeleteEntries = ChangeTracker.Entries<ISoftDelete>()
           .Where(_ => _.State == EntityState.Deleted);

        foreach (var entityEntry in softDeleteEntries)
        {
            entityEntry.State = EntityState.Modified;

            var entity = entityEntry.Entity;

            entity.IsActive = false;
            entity.DeletedOn = now;
            entity.DeletedBy = userId;
        }
    }

    private void CreateAndUpdateEntries(DateTime now, long userId, CancellationToken cancellationToken = default)
    {
        var newEntries = ChangeTracker.Entries<IAuditedEntity>()
            .Where(_ => _.State.In(EntityState.Modified, EntityState.Added));

        foreach (var entityEntry in newEntries)
        {
            var entity = entityEntry.Entity;

            entity.ModifiedOn = now;
            entity.ModifiedBy = userId;

            if (entityEntry.State == EntityState.Added)
            {
                entity.IsActive = true;
                entity.CreatedOn = now;
                entity.CreatedBy = userId;
            }
        }
    }

    private (DateTime now, long userId) GetAuditInfo()
    {
        var now = DateTime.UtcNow;

        var userId = CurrentUser.Id;

        if (userId == default)
            userId = Constants.SYSTEM_USER_ID;

        return (now, userId);
    }
}