using Task = Domain.TaskModule.Task;

namespace Application.Contracts.Persistence.Repositories;

public interface ITaskRepository : IAsyncRepository<Task>
{ 
    
}