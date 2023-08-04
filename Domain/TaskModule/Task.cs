using Domain.UserModule;

namespace Domain.TaskModule;

public class Task
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? SubmissionDate { get; set; }
    
    public int? AssignedToId { get; set; }
    public int? AssignedById { get; set; }
    
    public Employee? AssignedTo { get; set; }
    public Manager? AssignedBy { get; set; } = null!;
}