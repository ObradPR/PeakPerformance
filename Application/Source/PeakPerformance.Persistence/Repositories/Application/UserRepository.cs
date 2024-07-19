using Microsoft.EntityFrameworkCore;
using PeakPerformance.Domain.Entities.Application;
using PeakPerformance.Domain.Repositories.Application;
using PeakPerformance.Persistence.Contexts;
using PeakPerformance.Persistence.Repositories._Base;

namespace PeakPerformance.Persistence.Repositories.Application;

public class UserRepository(ApplicationDbContext context) : BaseRepository(context), IUserRepository
{
    // Get

    public async Task<User?> GetExistingUserAsync(string email, string username, bool strict, CancellationToken cancellationToken = default)
        => strict
            ? await Context.Users.SingleOrDefaultAsync(_ => _.Email.Equals(email) && _.Username.Equals(username), cancellationToken)
            : await Context.Users.SingleOrDefaultAsync(_ => _.Email.Equals(email) || _.Username.Equals(username), cancellationToken);

    public async Task<User?> GetUserByUsernameAsync(string username, CancellationToken cancellationToken = default)
        => await Context.Users
        .Include(_ => _.UserRoles)
        .ThenInclude(_ => _.Role)
        .SingleOrDefaultAsync(_ => _.Username.Equals(username), cancellationToken);

    // Add, Remove, Edit

    public async Task AddAsync(User user, CancellationToken cancellationToken = default)
        => await Context.Users.AddAsync(user, cancellationToken);
}