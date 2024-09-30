namespace PeakPerformance.Domain.Repositories.Application;

public interface IUserRepository
{
    // Get

    Task<User> GetExistingUserAsync(string email, string username, bool strict);

    Task<User> GetUserByUsernameAsync(string username);

    // Add / Remove / Edit

    Task AddAsync(User user);
}