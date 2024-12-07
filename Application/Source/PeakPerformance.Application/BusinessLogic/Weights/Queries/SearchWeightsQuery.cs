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
                predicates.Add(_ => _.CreatedOn >= request.Options.FromDate.Value);

            if (request.Options.ToDate.IsNotNullOrEmpty())
                predicates.Add(_ => _.CreatedOn <= request.Options.ToDate.Value);

            var result = await _unitOfWork.WeightRepository.SearchAsync(options, predicates);

            var mapping = _mapper.Map<IEnumerable<WeightDto>>(result.Data);

            return new PagingResult<WeightDto>
            {
                Data = _mapper.Map<IEnumerable<WeightDto>>(result.Data),
                Total = result.Total,
            };
        }
    }
}