namespace PeakPerformance.Persistence.Repositories.Application;

public class UserRepository(ApplicationDbContext context) : BaseRepository(context), IUserRepository
{
    // Get

    public async Task<User> GetExistingAsync(string email, string username, bool strict)
        => await db.Users.GetSingleAsync(_ => strict
            ? _.Email == email && _.Username == username
            : _.Email == email || _.Username == username);

    public async Task<User> GetByUsernameAsync(string username)
        => await db.Users.GetSingleAsync(_ => _.Username == username,
            includeProperties: [
                _ => _.UserRoles,
                _ => _.UserRoles.Select(_ => _.Role)
            ]);

    public async Task<User> GetByIdAsync(long id) => await db.Users.GetSingleAsync(id);

    public async Task<User> GetByIdAsync(Expression<Func<User, bool>> predicate, params Expression<Func<User, object>>[] includeProperties)
        => await db.Users.GetSingleAsync(predicate, includeProperties);

    public async Task<bool> CheckByIdAsync(long id) => await db.Users.AnyAsync(_ => _.Id == id);

    // Add / Remove / Edit

    public async Task AddAsync(User user) => await db.CreateAsync(user);
}