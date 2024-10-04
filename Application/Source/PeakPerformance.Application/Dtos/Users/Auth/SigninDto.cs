namespace PeakPerformance.Application.Dtos.Users.Auth;

public class SigninDto
{
    [Display(Name = "Username")]
    public string Username { get; set; }

    [Display(Name = "Password")]
    public string Password { get; set; }
}