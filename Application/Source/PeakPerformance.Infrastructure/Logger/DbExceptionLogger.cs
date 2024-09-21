using PeakPerformance.Common.Interfaces;
using PeakPerformance.Domain.Entities.Application;
using PeakPerformance.Domain.Repositories;

namespace PeakPerformance.Infrastructure.Logger;

public class DbExceptionLogger(IUnitOfWork unitOfWork) : IExceptionLogger
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task LogExceptionAsync(Exception ex)
    {
        var error = new ErrorLog()
        {
            Message = ex.Message,
            StackTrace = ex.StackTrace,
            InnerException = ex.InnerException?.Message
        };

        await _unitOfWork.ErrorLogRepository.AddAsync(error);

        await _unitOfWork.SaveAsync();
    }
}