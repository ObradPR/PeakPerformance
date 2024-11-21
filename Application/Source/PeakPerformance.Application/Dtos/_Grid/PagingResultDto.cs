namespace PeakPerformance.Application.Dtos._Grid;

public class PagingResultDto
{
    public IEnumerable<object> Data { get; set; }

    public long Total { get; set; }
}