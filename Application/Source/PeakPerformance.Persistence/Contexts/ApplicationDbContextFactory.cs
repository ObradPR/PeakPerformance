using Microsoft.EntityFrameworkCore.Design;

namespace PeakPerformance.Persistence.Contexts;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        IIdentityUser identityUser = null;
        return new ApplicationDbContext(identityUser);
    }
}