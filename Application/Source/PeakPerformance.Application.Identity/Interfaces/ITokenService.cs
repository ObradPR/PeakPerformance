namespace PeakPerformance.Application.Identity.Interfaces;

public interface ITokenService
{
    string GenerateJwtToken(long userId, string[] roles, string fullName, string email, string username);
}