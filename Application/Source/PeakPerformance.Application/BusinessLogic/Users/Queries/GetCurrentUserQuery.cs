using PeakPerformance.Application.Dtos.Users;

namespace PeakPerformance.Application.BusinessLogic.Users.Queries;

public class GetCurrentUserQuery : BaseQuery<UserDto>
{
    public class GetCurrentUserQueryHandler(IUnitOfWork unitOfWork, IIdentityUser identityUser, IMapper mapper)
        : BaseQueryHandler<GetCurrentUserQuery, UserDto>(unitOfWork, identityUser, mapper)
    {
        public override async Task<UserDto> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetSingleAsync(_ => _.Id == _identityUser.Id,
                includeProperties: [
                    _ => _.UserMeasurementPreferences
                ])
                ?? throw new NotFoundException();

            var userdto = _mapper.Map<UserDto>(user);

            return _mapper.Map<UserDto>(user);
        }
    }
}