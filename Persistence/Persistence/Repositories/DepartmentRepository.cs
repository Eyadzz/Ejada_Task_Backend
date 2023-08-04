using Application.Contracts.Persistence.Repositories;
using Domain.DepartmentModule;
using Persistence.DatabaseConfig;

namespace Persistence.Persistence.Repositories;

public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
{
    public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext) {}
    
    public async Task<ICollection<Employee>> GetDepartmentEmployees(int departmentId)
    {
        return await DbContext.Employees.AsNoTracking()
            .Include(e => e.User)
            .Where(d => d.Id == departmentId)
            .ToListAsync();
    }

    public async Task<ICollection<Department>> GetAllWithManagers()
    {
        return await DbContext.Departments.AsNoTracking()
            .Include(d => d.Manager)
            .ThenInclude(m => m.User)
            .ToListAsync();
    }
}