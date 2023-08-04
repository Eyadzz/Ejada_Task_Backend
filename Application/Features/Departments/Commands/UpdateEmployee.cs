using Application.Contracts.Services;
using Application.Mappings;
using Domain.UserModule;

namespace Application.Features.Departments.Commands;

public class UpdateEmployee : IRequest<BaseResponse>, IMapFrom<User>
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateEmployee, User>().
            ForMember(d => d.Id, opt => opt.Ignore()).
            ReverseMap();
    }
}

public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployee, BaseResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _currentUserService;

    public UpdateEmployeeHandler(IUnitOfWork unitOfWork, IMapper mapper, ICurrentUserService currentUserService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _currentUserService = currentUserService;
    }

    public async Task<BaseResponse> Handle(UpdateEmployee request, CancellationToken cancellationToken)
    {
        var employee = await _unitOfWork.Employees.EmployeeDetails(request.Id);
        if (employee == null)
            Responses.NotFound("Employee");

        var manager = await _unitOfWork.Managers.GetByUserId(_currentUserService.UserId);
        
        if (manager!.DepartmentId != employee!.DepartmentId)
            Responses.Unauthorized();
        
        _mapper.Map(request, employee.User);
        
        _unitOfWork.Employees.Update(employee);
        await _unitOfWork.Save();

        return Responses.Success();
    }
}