using PeakPerformance.Persistence.Contexts;

namespace PeakPerformance.Persistence.Repositories._Base;

public abstract class BaseRepository(ApplicationDbContext context)
{
    protected ApplicationDbContext Context { get; set; } = context;
}