namespace PeakPerformance.Domain.Repositories.Application;

public interface IUserRepository
{
    // Get
    Task<User> GetSingleAsync(long id);

    Task<User> GetSingleAsync(Expression<Func<User, bool>> predicate, params Expression<Func<User, object>>[] includeProperties);

    Task<User> GetExistingAsync(string email, string username, bool strict);

    Task<User> GetByUsernameAsync(string username);

    Task<bool> CheckByIdAsync(long id);

    // Add / Remove / Edit

    Task AddAsync(User user);
}