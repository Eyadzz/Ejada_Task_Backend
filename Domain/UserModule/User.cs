using Domain.DepartmentModule;
using Task = Domain.TaskModule.Task;

namespace Domain.UserModule;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime BirthDate { get; set; }

    public int RoleId { get; set; }

    public Role Role { get; set; } = null!;
    public Manager Manager { get; set; } = null!;
    public Employee Employee { get; set; } = null!;
}