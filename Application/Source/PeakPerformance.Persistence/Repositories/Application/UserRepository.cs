namespace PeakPerformance.Persistence.Repositories.Application;

public class UserRepository(ApplicationDbContext context) : BaseRepository(context), IUserRepository
{
    // Get

    public async Task<User> GetExistingUserAsync(string email, string username, bool strict)
        => await db.Users.GetSingleAsync(_ => strict
            ? _.Email == email && _.Username == username
            : _.Email == email || _.Username == username);

    public async Task<User> GetUserByUsernameAsync(string username)
        => await db.Users.GetSingleAsync(_ => _.Username == username,
            includeProperties: [
                _ => _.UserRoles,
                _ => _.UserRoles.Select(_ => _.Role)
            ]);

    // Add / Remove / Edit

    public async Task AddAsync(User user) => await db.CreateAsync(user);
}