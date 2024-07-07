namespace PeakPerformance.Application.Identity.Interfaces;

public interface IUserManager
{
    string HashPassword(string password);

    bool VerifyPassword(string password, string storedPassword);
}