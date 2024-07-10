using PeakPerformance.Domain.Repositories.Application;

namespace PeakPerformance.Domain.Repositories;

public interface IUnitOfWork
{
    // Repositories

    IErrorLogRepository ErrorLogRepository { get; }

    IUserRepository UserRepository { get; }

    IUserActivityLogRepository UserActivityLogRepository { get; }

    // Methods

    Task<bool> SaveAsync();
}