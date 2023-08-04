using Application.Mappings;
using Domain.UserModule;

namespace Application.Features.Users.Dto;

public class RoleDto : IMapFrom<Role>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Role, RoleDto>().ReverseMap();
    }
}