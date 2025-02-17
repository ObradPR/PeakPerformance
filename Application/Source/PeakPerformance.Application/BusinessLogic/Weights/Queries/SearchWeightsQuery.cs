namespace PeakPerformance.Application.BusinessLogic.Weights.Queries;

public class SearchWeightsQuery(WeightSearchOptions options) : BaseQuery<PagingResult<WeightDto>>
{
    public WeightSearchOptions Options { get; set; } = options;

    public class SearchWeightsQueryHandler(IUnitOfWork unitOfWork, IIdentityUser identityUser, IMapper mapper)
                : BaseQueryHandler<SearchWeightsQuery, PagingResult<WeightDto>>(unitOfWork, identityUser, mapper)
    {
        public override async Task<PagingResult<WeightDto>> Handle(SearchWeightsQuery request, CancellationToken cancellationToken)
        {
            var options = request.Options;

            var userId = options.UserId ?? _identityUser.Id;

            var userExists = await _unitOfWork.UserRepository.CheckByIdAsync(userId);

            if (!userExists)
                throw new NotFoundException();

            var predicates = new List<Expression<Func<Weight, bool>>>();

            if (userId.IsNotEmpty())
                predicates.Add(_ => _.UserId == userId);

            if (request.Options.FromDate.IsNotNullOrEmpty())
                predicates.Add(_ => _.LogDate >= request.Options.FromDate.Value);

            if (request.Options.ToDate.IsNotNullOrEmpty())
                predicates.Add(_ => _.LogDate <= request.Options.ToDate.Value);

            if (request.Options.ChartTimespanId.HasValue)
            {
                var chartTimespanId = request.Options.ChartTimespanId;
                var today = Functions.TODAY;

                if (chartTimespanId == eChartTimespan.Last3Months)
                    predicates.Add(_ => _.LogDate <= today && _.LogDate >= today.AddMonths(-3));
                else if (chartTimespanId == eChartTimespan.Last6Months)
                    predicates.Add(_ => _.LogDate <= today && _.LogDate >= today.AddMonths(-6));
                else if (chartTimespanId == eChartTimespan.Last12Months)
                    predicates.Add(_ => _.LogDate <= today && _.LogDate >= today.AddMonths(-12));
            }

            var result = await _unitOfWork.WeightRepository.SearchAsync(options, predicates);

            return new PagingResult<WeightDto>
            {
                Data = _mapper.Map<IEnumerable<WeightDto>>(result.Data),
                Total = result.Total,
            };
        }
    }
}