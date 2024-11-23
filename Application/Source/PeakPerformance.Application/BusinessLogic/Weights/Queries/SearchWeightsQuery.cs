using PeakPerformance.Domain.Searches;
using System.Linq.Expressions;

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

            var id = options.UserId ?? _identityUser.Id;

            var userExists = await _unitOfWork.UserRepository.CheckByIdAsync(id);

            if (!userExists)
                throw new NotFoundException();

            var predicates = new List<Expression<Func<Weight, bool>>>();

            if (id.IsNotEmpty())
                predicates.Add(_ => _.Id == id);

            var result = await _unitOfWork.WeightRepository.SearchAsync(options, predicates);

            return new PagingResult<WeightDto>
            {
                Data = _mapper.Map<IEnumerable<WeightDto>>(result.Data),
                Total = result.Total,
            };
        }
    }
}