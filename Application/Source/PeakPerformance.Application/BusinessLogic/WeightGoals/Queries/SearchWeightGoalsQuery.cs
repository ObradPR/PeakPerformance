namespace PeakPerformance.Application.BusinessLogic.WeightGoals.Queries;

public class SearchWeightGoalsQuery(WeightGoalSearchOptions options) : BaseQuery<PagingResult<WeightGoalDto>>
{
    public WeightGoalSearchOptions Options { get; set; } = options;

    public class SearchWeightGoalsQueryHandler(IUnitOfWork unitOfWork, IIdentityUser identityUser, IMapper mapper)
                : BaseQueryHandler<SearchWeightGoalsQuery, PagingResult<WeightGoalDto>>(unitOfWork, identityUser, mapper)
    {
        public override async Task<PagingResult<WeightGoalDto>> Handle(SearchWeightGoalsQuery request, CancellationToken cancellationToken)
        {
            var options = request.Options;

            var userId = options.UserId ?? _identityUser.Id;

            var userExists = await _unitOfWork.UserRepository.CheckByIdAsync(userId);

            if (!userExists)
                throw new NotFoundException();

            var predicates = new List<Expression<Func<WeightGoal, bool>>>();

            if (userId.IsNotEmpty())
                predicates.Add(_ => _.UserId == userId);

            if (request.Options.FromDate.IsNotNullOrEmpty())
                predicates.Add(_ => _.StartDate >= request.Options.FromDate.Value);

            if (request.Options.ToDate.IsNotNullOrEmpty())
                predicates.Add(_ => _.EndDate <= request.Options.ToDate.Value);

            if (request.Options.ChartTimespanId.HasValue)
            {
                var chartTimespanId = request.Options.ChartTimespanId;
                var today = Functions.TODAY;

                if (chartTimespanId == eChartTimespan.Last3Months)
                    predicates.Add(_ => _.StartDate <= today && _.StartDate >= today.AddMonths(-3));
                else if (chartTimespanId == eChartTimespan.Last6Months)
                    predicates.Add(_ => _.StartDate <= today && _.StartDate >= today.AddMonths(-6));
                else if (chartTimespanId == eChartTimespan.Last12Months)
                    predicates.Add(_ => _.StartDate <= today && _.StartDate >= today.AddMonths(-12));
            }

            var result = await _unitOfWork.WeightGoalRepository.SearchAsync(options, predicates);

            return new PagingResult<WeightGoalDto>
            {
                Data = _mapper.Map<IEnumerable<WeightGoalDto>>(result.Data),
                Total = result.Total,
            };
        }
    }
}