using PeakPerformance.Domain.Entities.Application;

namespace PeakPerformance.Domain.Repositories;

public interface IErrorLogRepository
{
    // Get

    // Add, Remove, Edit

    Task AddAsync(ErrorLog error);
}