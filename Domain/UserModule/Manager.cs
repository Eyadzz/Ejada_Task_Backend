using Domain.DepartmentModule;
using Task = Domain.TaskModule.Task;

namespace Domain.UserModule;

public class Manager
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public int? DepartmentId { get; set; }
    
    public Department? Department { get; set; }
    public User User { get; set; } = null!;
    public ICollection<Task>? Tasks{ get; set; } = null!;
}