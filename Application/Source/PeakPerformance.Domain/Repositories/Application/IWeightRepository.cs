﻿using System.Linq.Expressions;

namespace PeakPerformance.Domain.Repositories.Application;

public interface IWeightRepository
{
    // Get

    Task<PagingResult<Weight>> SearchAsync(WeightSearchOptions options, List<Expression<Func<Weight, bool>>> predicates);

    // Add / Remove / Edit

    Task AddAsync(Weight model);
}