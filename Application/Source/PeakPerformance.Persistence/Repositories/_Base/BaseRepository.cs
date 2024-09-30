namespace PeakPerformance.Persistence.Repositories._Base;

public abstract class BaseRepository(ApplicationDbContext context)
{
    protected ApplicationDbContext db => context;
}