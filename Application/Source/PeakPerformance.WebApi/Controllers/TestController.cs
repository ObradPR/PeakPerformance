﻿using Microsoft.AspNetCore.Mvc;
using PeakPerformance.Common.Exceptions;
using PeakPerformance.WebApi.Controllers._Base;

namespace PeakPerformance.WebApi.Controllers;

public class TestController : BaseController
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