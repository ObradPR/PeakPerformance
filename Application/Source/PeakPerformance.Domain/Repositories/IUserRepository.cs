using PeakPerformance.Domain.Entities.Application;

namespace PeakPerformance.Domain.Repositories;

public interface IUserRepository
{
    // Get

    Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default);

    // Add, Remove, Edit

    Task AddAsync(User user, CancellationToken cancellationToken);
}