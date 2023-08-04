using Application.Contracts.Persistence.Repositories;
using Persistence.DatabaseConfig;
using Task = Domain.TaskModule.Task;

namespace Persistence.Persistence.Repositories;

public class TaskRepository : BaseRepository<Task>, ITaskRepository
{
    public TaskRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}