namespace PeakPerformance.WebApi.Objects;

public class ExceptionResponse
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;
}

public class ValidationExceptionResponse : ExceptionResponse
{
    public Dictionary<string, string[]> Error { get; set; } = [];
}