﻿using HealthInformation_ = PeakPerformance.Domain.Entities.Application.HealthInformation;

namespace PeakPerformance.Application.BusinessLogic.HealthInformation.Queries;

public class SearchHealthInformationQuery(HealthInformationSearchOptions options) : BaseQuery<PagingResult<HealthInformationDto>>
{
    public HealthInformationSearchOptions Options { get; set; } = options;

    public class SearchHealthInformationQueryHandler(IUnitOfWork unitOfWork, IIdentityUser identityUser, IMapper mapper)
                : BaseQueryHandler<SearchHealthInformationQuery, PagingResult<HealthInformationDto>>(unitOfWork, identityUser, mapper)
    {
        public override async Task<PagingResult<HealthInformationDto>> Handle(SearchHealthInformationQuery request, CancellationToken cancellationToken)
        {
            var options = request.Options;

            var id = options.UserId ?? _identityUser.Id;

            var userExists = await _unitOfWork.UserRepository.CheckByIdAsync(id);

            if (!userExists)
                throw new NotFoundException();

            var predicates = new List<Expression<Func<HealthInformation_, bool>>>();

            if (id.IsNotEmpty())
                predicates.Add(_ => _.Id == id);

            var result = await _unitOfWork.HealthInformationRepository.SearchAsync(options, predicates);

            return new PagingResult<HealthInformationDto>
            {
                Data = _mapper.Map<IEnumerable<HealthInformationDto>>(result.Data),
                Total = result.Total,
            };
        }
    }
}