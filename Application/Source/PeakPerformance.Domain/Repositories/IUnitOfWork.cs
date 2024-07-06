namespace PeakPerformance.Domain.Repositories;

public interface IUnitOfWork
{
    // Repositories

    IErrorLogRepository ErrorLogRepository { get; }

    // Methods

    Task<bool> SaveAsync();
}