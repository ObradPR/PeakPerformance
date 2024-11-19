using PeakPerformance.Application.Dtos.Users;

namespace PeakPerformance.Application.BusinessLogic.Users.Queries;

public class GetCurrentUserQuery() : BaseQuery<UserDto>
{
    public class GetCurrentUserQueryHandler(IUnitOfWork unitOfWork, IIdentityUser identityUser, IMapper mapper)
        : BaseQueryHandler<GetCurrentUserQuery, UserDto>(unitOfWork, identityUser, mapper)
    {
        public override async Task<UserDto> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(_ => _.Id == _identityUser.Id)
                ?? throw new NotFoundException();

            return _mapper.Map<UserDto>(user);
        }
    }
}