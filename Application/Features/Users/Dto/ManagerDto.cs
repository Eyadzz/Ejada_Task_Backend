using Application.Mappings;
using Domain.UserModule;

namespace Application.Features.Users.Dto;

public class ManagerDto : IMapFrom<Manager>
{
    
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Manager, ManagerDto>()
            .ForMember( d => d.Name
                , opt => opt.MapFrom( d => d.User.Name))
            .ForMember( d => d.Id
                , opt => opt.MapFrom( d => d.Id))
            .ForMember( d => d.Email
                , opt => opt.MapFrom( d => d.User.Email))
            .ReverseMap();
    }
}