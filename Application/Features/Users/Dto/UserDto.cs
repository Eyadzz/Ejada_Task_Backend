using Application.Mappings;
using Domain.UserModule;

namespace Application.Features.Users.Dto;

public class UserDto : IMapFrom<User>
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public DateOnly BirthDate { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, UserDto>()
            .ForMember(d => d.Role, opt => 
                opt.MapFrom(s => s.Role.Name))
            .ReverseMap();
    }
}