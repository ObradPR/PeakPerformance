using PeakPerformance.Domain.Entities.Application;

namespace PeakPerformance.Domain.Repositories.Application;

public interface IUserRepository
{
    // Get

    Task<User?> GetExistingUserAsync(string email, string username, bool strict, CancellationToken cancellationToken = default);

    Task<User?> GetUserByUsernameAsync(string username, CancellationToken cancellationToken = default);

    // Add, Remove, Edit

    Task AddAsync(User user, CancellationToken cancellationToken = default);
}