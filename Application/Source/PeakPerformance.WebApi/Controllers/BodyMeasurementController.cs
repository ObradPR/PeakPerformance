using PeakPerformance.Application.BusinessLogic.BodyMeasurements.Queries;
using PeakPerformance.Application.Dtos.BodyMeasurements;

namespace PeakPerformance.WebApi.Controllers;

public class BodyMeasurementController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost]
    [Authorization(eSystemRole.User, eSystemRole.Admin)]
    [AngularMethod(typeof(PagingResult<BodyMeasurementDto>))]
    public async Task<IActionResult> Search(BodyMeasurementSearchOptions options) => Ok(await Mediator.Send(new SearchBodyMeasurementsQuery(options)));
}