using PeakPerformance.Application.Dtos.Users;

namespace PeakPerformance.Application.Mappers;

public abstract class BaseAutoMapperProfile : Profile
{
}

public class AutoMappingProfiles : BaseAutoMapperProfile
{
    public AutoMappingProfiles()
    {
        CreateMap<User, UserDto>();

        CreateMap<Weight, WeightDto>()
            .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Value))
            .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn.Date));

        CreateMap<BodyMeasurement, BodyMeasurementDto>();

        CreateMap<HealthInformation, HealthInformationDto>();
    }
}