using PeakPerformance.Domain.Repositories;
using PeakPerformance.Persistence.Contexts;
using PeakPerformance.Persistence.Repositories._Base;

namespace PeakPerformance.Persistence.Repositories;

public class UnitOfWork(ApplicationDbContext context) : BaseRepository(context), IUnitOfWork
{
    // Repositories

    public IErrorLogRepository ErrorLogRepository => new ErrorLogRepository(Context);

    // Methods

    public async Task<bool> SaveAsync()
    {
        return await Context.SaveChangesAsync() > 0;
    }
}