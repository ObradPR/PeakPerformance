﻿using PeakPerformance.Domain.Entities.Application;
using PeakPerformance.Domain.Repositories;
using PeakPerformance.Persistence.Contexts;
using PeakPerformance.Persistence.Repositories._Base;

namespace PeakPerformance.Persistence.Repositories;

public class ErrorLogRepository(ApplicationDbContext context)
    : BaseRepository(context), IErrorLogRepository
{
    public void Add(ErrorLog error)
    {
        Context.ErrorLogs.Add(error);
    }
}