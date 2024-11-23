using PeakPerformance.Application.Dtos.Users;

namespace PeakPerformance.Application.Mappers;

public abstract class BaseAutoMapperProfile : Profile
{
}

public class AutoMappingProfiles : BaseAutoMapperProfile
{
    public AutoMappingProfiles()
    {
        // User

        CreateMap<User, UserDto>();

        // Weight

        CreateMap<Weight, WeightDto>();
    }
}