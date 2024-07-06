using PeakPerformance.Domain.Entities.Application;

namespace PeakPerformance.Domain.Repositories;

public interface IErrorLogRepository
{
    Task AddAsync(ErrorLog error);
}