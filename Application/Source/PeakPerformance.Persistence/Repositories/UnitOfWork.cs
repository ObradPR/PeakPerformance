using PeakPerformance.Domain.Repositories;
using PeakPerformance.Persistence.Contexts;
using PeakPerformance.Persistence.Repositories._Base;

namespace PeakPerformance.Persistence.Repositories;

public class UnitOfWork : BaseRepository, IUnitOfWork
{
    public UnitOfWork(ApplicationDbContext context) : base(context)
    {
    }

    // Repositories

    public IErrorLogRepository ErrorLogRepository => new ErrorLogRepository(Context);

    public IUserRepository UserRepository => new UserRepository(Context);

    // Methods

    public async Task<bool> SaveAsync()
        => await Context.SaveChangesAsync() > 0;
}