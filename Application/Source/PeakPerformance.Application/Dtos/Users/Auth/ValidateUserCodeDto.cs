namespace PeakPerformance.Application.Dtos.Users.Auth;

public class ValidateUserCodeDto
{
    public string Email { get; set; } = string.Empty;

    public int VerifyCode { get; set; }
}