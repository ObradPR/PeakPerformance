namespace PeakPerformance.Domain.Repositories.Application;

public interface IUserRepository
{
    // Get

    Task<User> GetExistingAsync(string email, string username, bool strict);

    Task<User> GetByUsernameAsync(string username);

    Task<User> GetByIdAsync(long id);

    Task<User> GetByIdAsync(Expression<Func<User, bool>> predicate, params Expression<Func<User, object>>[] includeProperties);

    Task<bool> CheckByIdAsync(long id);

    // Add / Remove / Edit

    Task AddAsync(User user);
}