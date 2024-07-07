using PeakPerformance.Application.Identity.Interfaces;

namespace PeakPerformance.Application.Identity.Services;

public class UserManager : IUserManager
{
    public string HashPassword(string password)
        => BCrypt.Net.BCrypt.HashPassword(password);

    public bool VerifyPassword(string password, string storedPassword)
        => BCrypt.Net.BCrypt.Verify(password, storedPassword);
}