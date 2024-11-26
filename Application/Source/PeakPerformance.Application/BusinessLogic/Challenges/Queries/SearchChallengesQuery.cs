using PeakPerformance.Application.Dtos.Challenges;

namespace PeakPerformance.Application.BusinessLogic.Challenges.Queries;

public class SearchChallengesQuery(ChallengeSearchOptions options) : BaseQuery<PagingResult<ChallengeDto>>
{
    public ChallengeSearchOptions Options { get; set; } = options;

    public class SearchChallengesQueryHandler(IUnitOfWork unitOfWork, IIdentityUser identityUser, IMapper mapper)
                : BaseQueryHandler<SearchChallengesQuery, PagingResult<ChallengeDto>>(unitOfWork, identityUser, mapper)
    {
        public override async Task<PagingResult<ChallengeDto>> Handle(SearchChallengesQuery request, CancellationToken cancellationToken)
        {
            var options = request.Options;

            var id = options.UserId ?? _identityUser.Id;

            var userExists = await _unitOfWork.UserRepository.CheckByIdAsync(id);

            if (!userExists)
                throw new NotFoundException();

            var predicates = new List<Expression<Func<Challenge, bool>>>();

            // OPR: The search for the challenges itself might not need a UserId but some different value, or we will search for the Challenges that the user Participates
            //if (id.IsNotEmpty())
            //    predicates.Add(_ => _.CreatedBy == id);

            var result = await _unitOfWork.ChallengeRepository.SearchAsync(options, predicates);

            return new PagingResult<ChallengeDto>
            {
                Data = _mapper.Map<IEnumerable<ChallengeDto>>(result.Data),
                Total = result.Total,
            };
        }
    }
}