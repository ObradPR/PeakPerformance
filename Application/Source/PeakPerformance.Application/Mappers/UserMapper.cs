using PeakPerformance.Application.Dtos.Users;

namespace PeakPerformance.Application.Mappers;

public class UserMapper : BaseAutoMapperProfile
{
    public UserMapper()
    {
        CreateMap<User, UserDto>();
    }
}