using Domain.UserModule;
using Task = Domain.TaskModule.Task;

namespace Application.Contracts.Persistence.Repositories;

public interface IManagerRepository : IAsyncRepository<Manager>
{
    Task<Manager?> GetManagerDetails(int managerId);
    Task<Manager?> GetByUserId(int userId);
    Task<ICollection<Task>> GetManagerTasks(int managerId);
    Task<ICollection<Manager>> GetManagersDetails();
}