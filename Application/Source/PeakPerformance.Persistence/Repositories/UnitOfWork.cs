namespace PeakPerformance.Persistence.Repositories;

public class UnitOfWork(ApplicationDbContext context) : BaseRepository(context), IUnitOfWork
{
    // Repositories

    public IErrorLogRepository ErrorLogRepository => new ErrorLogRepository(db);

    public IUserRepository UserRepository => new UserRepository(db);

    public IUserActivityLogRepository UserActivityLogRepository => new UserActivityLogRepository(db);

    // Methods

    public async Task<bool> SaveAsync() => await db.SaveChangesAsync() > 0;
}