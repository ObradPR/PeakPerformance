using PeakPerformance.Common.Interfaces;
using PeakPerformance.Domain.Entities.Application;
using PeakPerformance.Domain.Repositories;

namespace PeakPerformance.Infrastructure.Logger;

public class DbExceptionLogger(IUnitOfWork unitOfWork) : IExceptionLogger
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async void LogException(Exception ex)
    {
        ErrorLog error = new()
        {
            Message = ex.Message,
            StackTrace = ex.StackTrace,
            InnerException = ex.InnerException?.Message
        };

        _unitOfWork.ErrorLogRepository.Add(error);

        await _unitOfWork.SaveAsync();
    }
}