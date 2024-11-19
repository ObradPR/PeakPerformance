namespace PeakPerformance.Application.Dtos.Users;

public class ProfileSetupDto
{
    public WeightDto Weight { get; set; }

    public BodyMeasurementDto BodyMeasurement { get; set; }

    public UserTrainingGoalDto UserTrainingGoal { get; set; }

    public WeightGoalDto WeightGoal { get; set; }

    public BodyFatGoalDto BodyFatGoal { get; set; }

    public IFormFile Image { get; set; }

    public string Description { get; set; }

    public bool ReceiveNews { get; set; }

    public List<SocialMediaDto> SocialMedia { get; set; }

    public List<HealthInformationDto> HealthInformation { get; set; }
}