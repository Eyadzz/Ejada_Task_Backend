using Application.Contracts.Persistence.Repositories;
using Persistence.DatabaseConfig;
using Task = Domain.TaskModule.Task;

namespace Persistence.Persistence.Repositories;

public class ManagerRepository : BaseRepository<Manager>, IManagerRepository
{
    public ManagerRepository(ApplicationDbContext dbContext) : base(dbContext) {}

    public async Task<Manager?> GetManagerDetails(int managerId)
    {
        return await DbContext.Managers.AsNoTracking()
            .Include(m => m.Department)
            .Include(m => m.User)
            .SingleOrDefaultAsync(u => u.Id == managerId);
    }

    public async Task<Manager?> GetByUserId(int userId)
    {
        return await DbContext.Managers.AsNoTracking()
            .SingleOrDefaultAsync(m => m.UserId == userId);
    }

    public async Task<ICollection<Task>> GetManagerTasks(int managerId)
    {
        return await DbContext.Tasks.AsNoTracking()
            .Include(t => t.AssignedTo)
            .ThenInclude(e => e.User)
            .Where(t => t.AssignedById == managerId)
            .ToListAsync();
    }

    public async Task<ICollection<Manager>> GetManagersDetails()
    {
        return await DbContext.Managers.AsNoTracking()
            .Include(m => m.User)
            .ToListAsync();
    }
}