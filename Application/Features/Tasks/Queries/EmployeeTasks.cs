using Application.Contracts.Services;
using Application.Features.Tasks.Dto;
using Task = Domain.TaskModule.Task;

namespace Application.Features.Tasks.Queries;

public record EmployeeTasks() : IRequest<BaseResponse>;

public class EmployeeTasksHandler : IRequestHandler<EmployeeTasks, BaseResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;
    private readonly IMapper _mapper;

    public EmployeeTasksHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
        _mapper = mapper;
    }

    public async Task<BaseResponse> Handle(EmployeeTasks request, CancellationToken cancellationToken)
    {
        var employee = await _unitOfWork.Employees.GetByUserId(_currentUserService.UserId);
        
        var tasks = await _unitOfWork.Employees.EmployeeTasks(employee!.Id, pendingOnly: true);

        return Responses.Success(_mapper.Map<List<EmployeeTaskDto>>(tasks));
    }
}