using Microsoft.AspNetCore.Mvc;

namespace PeakPerformance.WebApi.Controllers._Base;

[Route("api/[controller]/[action]")]
[ApiController]
public abstract class BaseController : ControllerBase
{
}