namespace PeakPerformance.Application.Dtos.Users.Auth;

public class SignupDto
{
    [Display(Name = "First name")]
    public string FirstName { get; set; }

    [Display(Name = "Middle name")]
    public string? MiddleName { get; set; }

    [Display(Name = "Last name")]
    public string LastName { get; set; }

    [Display(Name = "Username")]
    public string Username { get; set; }

    [Display(Name = "Email")]
    public string Email { get; set; }

    [Display(Name = "Password")]
    public string Password { get; set; }

    [Display(Name = "Confirm password")]
    public string ConfirmPassword { get; set; }

    [Display(Name = "Date of birth")]
    public DateTime DateOfBirth { get; set; }

    [Display(Name = "Phone number")]
    public string PhoneNumber { get; set; }

    [Display(Name = "Verify code")]
    public int VerificationCode { get; set; }

    // methods

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
            RoleId = eSystemRole.User
        });

        if (isSigningUp)
            user.UserActivityLogs.Add(new UserActivityLog
            {
                ActionTypeId = eActionType.Signup
            });
    }
}