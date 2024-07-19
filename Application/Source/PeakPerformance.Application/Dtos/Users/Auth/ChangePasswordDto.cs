namespace PeakPerformance.Application.Dtos.Users.Auth;

public class ChangePasswordDto
{
    public string Username { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string ConfirmPassword { get; set; } = string.Empty;

    // Logic

    public void ChangePassword(User user, IUserManager userManager)
    {
        user.Password = userManager.HashPassword(Password);
        user.ModifiedBy = user.Id;
        user.ModifiedOn = DateTime.UtcNow;
    }
}