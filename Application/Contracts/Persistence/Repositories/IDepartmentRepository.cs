using Domain.DepartmentModule;
using Domain.UserModule;

namespace Application.Contracts.Persistence.Repositories;

public interface IDepartmentRepository : IAsyncRepository<Department>
{
    Task<ICollection<Employee>> GetDepartmentEmployees(int departmentId);
    Task<ICollection<Department>> GetAllWithManagers();
}