﻿using PeakPerformance.Domain.Entities.Application;
using PeakPerformance.Domain.Repositories.Application;
using PeakPerformance.Persistence.Contexts;
using PeakPerformance.Persistence.Repositories._Base;

namespace PeakPerformance.Persistence.Repositories.Application;

public class ErrorLogRepository(ApplicationDbContext context)
    : BaseRepository(context), IErrorLogRepository
{
    // Get

    // Add, Remove, Edit

    public async Task AddAsync(ErrorLog error)
        => await Context.ErrorLogs.AddAsync(error);
}