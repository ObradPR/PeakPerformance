using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PeakPerformance.WebApi.Controllers._Base;

[Route("api/[controller]/[action]")]
[ApiController]
public abstract class BaseController(IMediator mediator) : ControllerBase
{
    protected IMediator Mediator = mediator;
}