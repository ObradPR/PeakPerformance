namespace PeakPerformance.Domain.Repositories;

public interface IUnitOfWork
{
    // Repositories

    IErrorLogRepository ErrorLogRepository { get; }

    IUserRepository UserRepository { get; }

    // Methods

    Task<bool> SaveAsync();
}