using PeakPerformance.Domain.Entities.Application;

namespace PeakPerformance.Domain.Repositories;

public interface IErrorLogRepository
{
    void Add(ErrorLog error);
}