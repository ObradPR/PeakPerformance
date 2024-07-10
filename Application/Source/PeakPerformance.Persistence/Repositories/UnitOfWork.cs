using PeakPerformance.Domain.Repositories;
using PeakPerformance.Domain.Repositories.Application;
using PeakPerformance.Persistence.Contexts;
using PeakPerformance.Persistence.Repositories._Base;
using PeakPerformance.Persistence.Repositories.Application;

namespace PeakPerformance.Persistence.Repositories;

public class UnitOfWork(ApplicationDbContext context) : BaseRepository(context), IUnitOfWork
{
    // Repositories

    public IErrorLogRepository ErrorLogRepository => new ErrorLogRepository(Context);

    public IUserRepository UserRepository => new UserRepository(Context);

    public IUserActivityLogRepository UserActivityLogRepository => new UserActivityLogRepository(Context);

    // Methods

    public async Task<bool> SaveAsync()
        => await Context.SaveChangesAsync() > 0;
}