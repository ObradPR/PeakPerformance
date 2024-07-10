using PeakPerformance.Domain.Entities.Application;

namespace PeakPerformance.Domain.Repositories.Application;

public interface IErrorLogRepository
{
    // Get

    // Add, Remove, Edit

    Task AddAsync(ErrorLog error);
}