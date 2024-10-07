using PeakPerformance.Application.Exceptions;
using PeakPerformance.WebApi.Objects;
using System.Net;

namespace PeakPerformance.WebApi.Middlewares;

public class ExceptionMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context, IExceptionLogger logger)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex, logger);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex, IExceptionLogger logger)
    {
        await logger.LogExceptionAsync(ex);

        context.Response.ContentType = "application/json";

        context.Response.StatusCode = ex switch
        {
            NotFoundException _ => (int)HttpStatusCode.NotFound,
            UnauthorizedException _ => (int)HttpStatusCode.Unauthorized,
            ValidationException _ => (int)HttpStatusCode.BadRequest,
            ForbiddenException _ => (int)HttpStatusCode.Forbidden,
            FluentValidationException _ => (int)HttpStatusCode.UnprocessableEntity,
            EmailValidationException _ => (int)HttpStatusCode.BadRequest,
            VerificationCodeException _ => (int)HttpStatusCode.BadRequest,
            AccountExistsException _ => (int)HttpStatusCode.BadRequest,
            ServerErrorException _ => (int)HttpStatusCode.InternalServerError,
            _ => (int)HttpStatusCode.InternalServerError,
        };

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

        await context.Response.WriteAsync(response.SerializeJsonObject());
    }
}