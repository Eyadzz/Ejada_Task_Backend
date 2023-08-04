using Application.Mappings;
using Domain.DepartmentModule;

namespace Application.Features.Departments.Commands;

public class UpdateDepartment : IRequest<BaseResponse>, IMapFrom<Department>
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int? ManagerId { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateDepartment, Department>().ReverseMap();
    }
}

public class UpdateDepartmentHandler : IRequestHandler<UpdateDepartment, BaseResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateDepartmentHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse> Handle(UpdateDepartment request, CancellationToken cancellationToken)
    {
        var department = await _unitOfWork.Departments.GetAsync(request.Id);
        if (department is null)
            return Responses.NotFound("Department");

        if (request.ManagerId is not null)
        {
            var manager = await _unitOfWork.Managers.GetAsync((int) request.ManagerId);
            if (manager is null)
                return Responses.NotFound("Manager");
        }

        _mapper.Map(request, department);
        
        await _unitOfWork.Save();

        return Responses.Success();
    }
}