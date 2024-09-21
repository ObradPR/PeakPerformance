namespace PeakPerformance.Application.Dtos.Users.Auth;

public class SignupDto
{
    [Description("First Name")]
    public string FirstName { get; set; } = string.Empty;

    [Description("Middle Name")]
    public string? MiddleName { get; set; }

    [Description("Last Name")]
    public string LastName { get; set; } = string.Empty;

    [Description("Username")]
    public string Username { get; set; } = string.Empty;

    [Description("Email")]
    public string Email { get; set; } = string.Empty;

    [Description("Password")]
    public string Password { get; set; } = string.Empty;

    [Description("Confirm Password")]
    public string ConfirmPassword { get; set; } = string.Empty;

    [Description("Date of Birth")]
    public DateTime DateOfBirth { get; set; }

    [Description("Phone Number")]
    public string PhoneNumber { get; set; } = string.Empty;

    public int VerifyCode { get; set; }

    // Logic

    public void ToModel(User user, IUserManager userManager, bool isSigningUp = true)
    {
        user.FirstName = FirstName;
        user.MiddleName = MiddleName ?? null;
        user.LastName = LastName;
        user.Username = Username;
        user.Email = Email;
        user.Password = userManager.HashPassword(Password);
        user.DateOfBirth = DateOfBirth;
        user.PhoneNumber = PhoneNumber;

        user.UserRoles.Add(new UserRole
        {
            RoleId = (int)eSystemRole.User
        });

        if (isSigningUp)
            user.UserActivityLogs.Add(new UserActivityLog
            {
                ActionTypeId = (int)eActionType.Signup
            });
    }
}