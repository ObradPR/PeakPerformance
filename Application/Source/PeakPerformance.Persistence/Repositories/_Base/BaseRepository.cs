using PeakPerformance.Persistence.Contexts;

namespace PeakPerformance.Persistence.Repositories._Base;

public abstract class BaseRepository(ApplicationDbContext context) : IDisposable
{
    protected ApplicationDbContext Context { get; set; } = context;

    public void Dispose() => Context.Dispose();
}