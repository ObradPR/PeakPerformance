namespace PeakPerformance.Application.Dtos.Users.Auth;

public class ValidateUserCodeDto
{
    public string Email { get; set; }

    public int VerifyCode { get; set; }
}