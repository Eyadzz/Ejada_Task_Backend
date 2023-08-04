using Application.Mappings;
using Task = Domain.TaskModule.Task;

namespace Application.Features.Tasks.Dto;

public class EmployeeTaskDto : IMapFrom<Task>
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;
    public string Description { get; init; } = null!;
    public DateTime CreatedAt { get; init; }
    public int AssignedById { get; set; }
    public string AssignedByName { get; set; } = null!;
    public DateTime? SubmissionDate { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Task, EmployeeTaskDto>()
            .ForMember(d => d.AssignedByName, 
                opt => opt.MapFrom(s => s.AssignedBy!.User.Name))
            .ReverseMap();
    }
}