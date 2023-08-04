using Application.Mappings;
using Task = Domain.TaskModule.Task;

namespace Application.Features.Tasks.Dto;

public class ManagerTaskDto : IMapFrom<Task>
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;
    public string Description { get; init; } = null!;
    public DateTime CreatedAt { get; init; }
    public int AssignedToId { get; set; }
    public string AssignedToName { get; set; } = null!;
    public DateTime SubmissionDate { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Task, ManagerTaskDto>()
            .ForMember(d => d.AssignedToName, 
                opt => opt.MapFrom(s => s.AssignedTo!.User.Name))
            .ReverseMap();
    }
}