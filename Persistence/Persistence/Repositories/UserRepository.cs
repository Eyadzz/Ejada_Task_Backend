using Application.Contracts.Persistence.Repositories;
using Persistence.DatabaseConfig;

namespace Persistence.Persistence.Repositories;

public class UserRepository :  BaseRepository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext) {}

    public async Task<User?> GetUserByEmail(string email)
    {
        return await DbContext.Users.AsNoTracking()
            .Include(u => u.Role)
            .SingleOrDefaultAsync(u => u.Email == email);
    }

    public async Task<ICollection<Role>> GetAllRoles()
    {
        return await DbContext.Roles.AsNoTracking().ToListAsync();
    }

    public async Task<bool> EmailExists(string email)
    {
        return await DbContext.Users.AsNoTracking()
            .AnyAsync(u => u.Email == email);
    }

    public async Task<bool> PhoneNumberExists(string phoneNumber)
    {
       return await DbContext.Users.AsNoTracking()
            .AnyAsync(u => u.PhoneNumber == phoneNumber);
    }

    public async Task<ICollection<User>>? GetUsersByRole(string roleName)
    {
        return await DbContext.Users.AsNoTracking()
            .Include(u => u.Role)
            .Where(u => u.Role.Name == roleName)
            .ToListAsync();
    }

    public async Task<User?> GetUserWithRole(int userId)
    {
        return await DbContext.Users.AsNoTracking()
            .Include(u => u.Role)
            .SingleOrDefaultAsync(u => u.Id == userId);
    }
}