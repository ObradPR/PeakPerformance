namespace PeakPerformance.WebApi.Controllers;

[Authorization(eSystemRole.Admin)]
public class TestController(IMediator mediator) : BaseController(mediator)
{
    [HttpGet("{id}")]
    public IActionResult Test([FromRoute] int id)
    {
        if (id == 0)
            throw new NotFoundException();

        if (id == 1)
            throw new UnauthorizedException();

        if (id == 2)
            throw new ValidationException();

        if (id == 3)
            throw new ServerErrorException();

        return Ok();
    }
}