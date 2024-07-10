using Microsoft.EntityFrameworkCore;
using PeakPerformance.Domain.Entities.Application;
using PeakPerformance.Domain.Repositories;
using PeakPerformance.Persistence.Contexts;
using PeakPerformance.Persistence.Repositories._Base;

namespace PeakPerformance.Persistence.Repositories;

public class UserRepository(ApplicationDbContext context) : BaseRepository(context), IUserRepository
{
    // Get

    public async Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default)
        => await Context.Users.SingleOrDefaultAsync(_ => _.Email.Equals(email), cancellationToken);

    // Add, Remove, Edit

    public async Task AddAsync(User user, CancellationToken cancellationToken)
        => await Context.Users.AddAsync(user, cancellationToken);
}