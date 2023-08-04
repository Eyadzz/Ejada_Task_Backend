using Application.Features.Tasks.Dto;

namespace Application.Features.Tasks.Queries;

public record EmployeeTasksForManager(int EmployeeId) : IRequest<BaseResponse>;

public class EmployeeTasksForManagerHandler : IRequestHandler<EmployeeTasksForManager, BaseResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EmployeeTasksForManagerHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse> Handle(EmployeeTasksForManager request, CancellationToken cancellationToken)
    {
        var employee = await _unitOfWork.Users.GetAsync(request.EmployeeId);
        if (employee == null)
            return Responses.NotFound("Employee");
            
        var tasks = await _unitOfWork.Employees.EmployeeTasks(request.EmployeeId, pendingOnly: false);
        
        return Responses.Success( _mapper.Map<List<EmployeeTaskDto>>(tasks));
    }
}