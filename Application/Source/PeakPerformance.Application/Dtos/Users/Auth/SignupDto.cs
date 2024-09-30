namespace PeakPerformance.Application.Dtos.Users.Auth;

public class SignupDto
{
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Display(Name = "Middle Name")]
    public string? MiddleName { get; set; }

    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Display(Name = "Username")]
    public string Username { get; set; }

    [Display(Name = "Email")]
    public string Email { get; set; }

    [Display(Name = "Password")]
    public string Password { get; set; }

    [Display(Name = "Confirm Password")]
    public string ConfirmPassword { get; set; }

    [Display(Name = "Date of Birth")]
    public DateTime DateOfBirth { get; set; }

    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }

    [Display(Name = "Verify Code")]
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