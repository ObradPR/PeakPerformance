using PeakPerformance.Application.Dtos.Users;

namespace PeakPerformance.Application.Mappers;

public abstract class BaseAutoMapperProfile : Profile
{
}

public class AutoMappingProfiles : BaseAutoMapperProfile
{
    public AutoMappingProfiles()
    {
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.WeightUnitId, opt => opt.MapFrom(src => src.UserMeasurementPreferences.FirstOrDefault().WeightUnitId))
            .ForMember(dest => dest.MeasurementUnitId, opt => opt.MapFrom(src => src.UserMeasurementPreferences.FirstOrDefault().MeasurementUnitId));

        CreateMap<Weight, WeightDto>()
            .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Value));

        CreateMap<WeightGoal, WeightGoalDto>();

        CreateMap<BodyMeasurement, BodyMeasurementDto>();

        CreateMap<HealthInformation, HealthInformationDto>();
    }
}