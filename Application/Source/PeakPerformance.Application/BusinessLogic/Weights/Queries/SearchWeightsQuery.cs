using PeakPerformance.Application.Dtos._Grid;
using PeakPerformance.Application.Dtos.Searches;

namespace PeakPerformance.Application.BusinessLogic.Weights.Queries;

public class SearchWeightsQuery(WeightSearchOptionsDto options) : BaseQuery<PagingResultDto>
{
    public WeightSearchOptionsDto Options { get; set; } = options;

    public class SearchWeightsQueryHandler(IUnitOfWork unitOfWork, IIdentityUser identityUser, IMapper mapper)
                : BaseQueryHandler<SearchWeightsQuery, PagingResultDto>(unitOfWork, identityUser, mapper)
    {
        public override async Task<PagingResultDto> Handle(SearchWeightsQuery request, CancellationToken cancellationToken)
        {
            var result = new PagingResultDto();
            result.Data = new List<WeightDto>();
            result.Total = 0;

            return result;
        }
    }
}