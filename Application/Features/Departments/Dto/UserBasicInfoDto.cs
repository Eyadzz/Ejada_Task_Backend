using Application.Mappings;
using Domain.UserModule;

namespace Application.Features.Departments.Dto;

public class UserBasicInfoDto : IMapFrom<Employee>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Employee, UserBasicInfoDto>()
            .ForMember( d => d.Name, opt => opt.MapFrom(s => s.User.Name))
            .ForMember( d => d.Id, opt => opt.MapFrom(s => s.Id))
            .ForMember( d => d.Email, opt => opt.MapFrom(s => s.User.Email))
            .ReverseMap();
    }
}