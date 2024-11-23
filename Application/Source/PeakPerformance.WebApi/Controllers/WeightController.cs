﻿using PeakPerformance.Application.BusinessLogic.Weights.Queries;
using PeakPerformance.Application.Dtos.Weights;
using PeakPerformance.Domain._Grid;
using PeakPerformance.Domain.Searches;

namespace PeakPerformance.WebApi.Controllers;

public class WeightController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost]
    [Authorization(eSystemRole.User, eSystemRole.Admin)]
    [AngularMethod(typeof(PagingResult<WeightDto>))]
    public async Task<IActionResult> Search(WeightSearchOptions options) => Ok(await Mediator.Send(new SearchWeightsQuery(options)));
}