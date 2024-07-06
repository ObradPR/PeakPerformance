using PeakPerformance.Application.Exceptions;
using PeakPerformance.Common.Exceptions;
using PeakPerformance.Common.Extensions;
using PeakPerformance.WebApi.Objects;
using System.Net;

namespace PeakPerformance.WebApi.Middlewares;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ExceptionMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";

        context.Response.StatusCode = ex switch
        {
            NotFoundException _ => (int)HttpStatusCode.NotFound,
            UnauthorizedException _ => (int)HttpStatusCode.Unauthorized,
            ValidationException _ => (int)HttpStatusCode.BadRequest,
            FluentValidationException _ => (int)HttpStatusCode.UnprocessableEntity,
            ServerErrorException _ => (int)HttpStatusCode.InternalServerError,
            _ => (int)HttpStatusCode.InternalServerError,
        };

        _logger.LogError(ex, ex.Message);

        var response = new ExceptionResponse();

        if (ex is FluentValidationException validationException)
        {
            response = new ValidationExceptionResponse
            {
                Message = validationException.Message,
                Error = validationException.Failures.ToDictionary(
                    _ => _.Key,
                    _ => _.Value)
            };
        }
        else
        {
            response = new ExceptionResponse
            {
                Message = ex.Message,
            };
        }

        response.StatusCode = context.Response.StatusCode;

        await context.Response.WriteAsync(response.ToJson());
    }
}