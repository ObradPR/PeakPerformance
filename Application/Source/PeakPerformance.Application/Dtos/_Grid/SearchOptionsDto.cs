namespace PeakPerformance.Application.Dtos._Grid;

public class SearchOptionsDto
{
    public int Skip { get; set; }

    public int Take { get; set; }

    public List<SortingOptionsDto> SortingOptions { get; set; }

    public string Filter { get; set; }

    public bool? TotalCount { get; set; }
}
