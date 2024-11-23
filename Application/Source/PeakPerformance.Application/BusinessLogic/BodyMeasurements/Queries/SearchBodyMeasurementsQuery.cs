namespace PeakPerformance.Application.BusinessLogic.BodyMeasurements.Queries;

public class SearchBodyMeasurementsQuery(BodyMeasurementSearchOptions options) : BaseQuery<PagingResult<BodyMeasurementDto>>
{
    public BodyMeasurementSearchOptions Options { get; set; } = options;

    public class SearchBodyMeasurementsQueryHandler(IUnitOfWork unitOfWork, IIdentityUser identityUser, IMapper mapper)
                : BaseQueryHandler<SearchBodyMeasurementsQuery, PagingResult<BodyMeasurementDto>>(unitOfWork, identityUser, mapper)
    {
        public override async Task<PagingResult<BodyMeasurementDto>> Handle(SearchBodyMeasurementsQuery request, CancellationToken cancellationToken)
        {
            var options = request.Options;

            var id = options.UserId ?? _identityUser.Id;

            var userExists = await _unitOfWork.UserRepository.CheckByIdAsync(id);

            if (!userExists)
                throw new NotFoundException();

            var predicates = new List<Expression<Func<BodyMeasurement, bool>>>();

            if (id.IsNotEmpty())
                predicates.Add(_ => _.Id == id);

            var result = await _unitOfWork.BodyMeasurementRepository.SearchAsync(options, predicates);

            return new PagingResult<BodyMeasurementDto>
            {
                Data = _mapper.Map<IEnumerable<BodyMeasurementDto>>(result.Data),
                Total = result.Total,
            };
        }
    }
}