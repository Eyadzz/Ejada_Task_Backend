using Application.Contracts.Services;
using Application.Features.Departments.Dto;

namespace Application.Features.Departments.Queries;

public record DepartmentEmployees() : IRequest<BaseResponse>;

public class EmployeesHandler : IRequestHandler<DepartmentEmployees, BaseResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _currentUserService;

    public EmployeesHandler(IUnitOfWork unitOfWork, IMapper mapper, ICurrentUserService currentUserService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _currentUserService = currentUserService;
    }

    public async Task<BaseResponse> Handle(DepartmentEmployees request, CancellationToken cancellationToken)
    {
        var manager = await _unitOfWork.Managers.GetByUserId(_currentUserService.UserId);
        
        var employees = await _unitOfWork.Departments.GetDepartmentEmployees((int) manager!.DepartmentId);
        
        return Responses.Success(_mapper.Map<ICollection<UserBasicInfoDto>>(employees));
    }
}