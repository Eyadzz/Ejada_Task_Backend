using Application.Mappings;
using Domain.DepartmentModule;

namespace Application.Features.Departments.Dto;

public class DepartmentDto : IMapFrom<Department>
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int? ManagerId { get; set; }
    public string ManagerName { get; set; } = null!;
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Department, DepartmentDto>()
            .ForMember( d => d.ManagerName
                , opt => opt.MapFrom( d => d.Manager!.User.Name))
            .ForMember( d => d.ManagerId
                , opt => opt.MapFrom( d => d.Manager!.Id))
            .ReverseMap();
    }
}