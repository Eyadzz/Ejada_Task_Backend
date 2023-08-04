using Domain.UserModule;
using Task = Domain.TaskModule.Task;

namespace Application.Contracts.Persistence.Repositories;

public interface IEmployeeRepository : IAsyncRepository<Employee>
{
    Task<Employee?> EmployeeDetails(int employeeId);
    Task<Employee?> GetByUserId(int userId);
    Task<ICollection<Task>> EmployeeTasks(int employeeId, bool pendingOnly);
}