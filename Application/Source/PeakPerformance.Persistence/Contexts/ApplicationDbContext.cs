using Microsoft.EntityFrameworkCore;

namespace PeakPerformance.Persistence.Contexts;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    { }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=PeakPerformance;TrustServerCertificate=True;Integrated security=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}