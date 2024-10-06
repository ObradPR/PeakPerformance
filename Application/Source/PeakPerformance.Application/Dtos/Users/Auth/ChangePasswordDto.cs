namespace PeakPerformance.Application.Dtos.Users.Auth;

public class ChangePasswordDto
{
    public string Username { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string ConfirmPassword { get; set; }

    // methods

    public void ChangePassword(User user, IUserManager userManager)
    {
        user.Password = userManager.HashPassword(Password);
        user.ModifiedBy = user.Id;
    }
}