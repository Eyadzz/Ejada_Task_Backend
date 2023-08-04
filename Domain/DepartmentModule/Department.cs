using Domain.UserModule;

namespace Domain.DepartmentModule;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public int? ManagerId { get; set; }
    public Manager? Manager { get; set; }
    public ICollection<Employee>? Employees { get; set; } = null!;
}