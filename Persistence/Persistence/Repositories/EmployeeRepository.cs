using Application.Contracts.Persistence.Repositories;
using Persistence.DatabaseConfig;
using Task = Domain.TaskModule.Task;

namespace Persistence.Persistence.Repositories;

public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository 
{
    public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext) {}

    public async Task<Employee?> EmployeeDetails(int employeeId)
    {
        return await DbContext.Employees.AsNoTracking()
            .Include(e => e.Department)
            .Include(e => e.User)
            .SingleOrDefaultAsync(u => u.Id == employeeId);
    }

    public async Task<Employee?> GetByUserId(int userId)
    {
        return await DbContext.Employees.AsNoTracking()
            .SingleOrDefaultAsync(u => u.UserId == userId);
    }

    public async Task<ICollection<Task>> EmployeeTasks(int employeeId, bool pendingOnly)
    {
        var query = DbContext.Tasks.AsNoTracking()
            .Include(t => t.AssignedBy)
            .ThenInclude(u => u!.User)
            .Where(t => t.AssignedToId == employeeId).AsQueryable();

        if (pendingOnly)
            query = query.Where(t => t.SubmissionDate == null);
        
        return await query.ToListAsync();
    }
}