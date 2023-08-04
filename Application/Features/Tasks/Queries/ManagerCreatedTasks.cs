using Application.Contracts.Services;
using Application.Features.Tasks.Dto;

namespace Application.Features.Tasks.Queries;

public record ManagerCreatedTasks() : IRequest<BaseResponse>;


public class ManagerCreatedTasksHandler : IRequestHandler<ManagerCreatedTasks, BaseResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _currentUserService;

    public ManagerCreatedTasksHandler(IUnitOfWork unitOfWork, IMapper mapper, ICurrentUserService currentUserService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _currentUserService = currentUserService;
    }

    public async Task<BaseResponse> Handle(ManagerCreatedTasks request, CancellationToken cancellationToken)
    {
        var manager = await _unitOfWork.Managers.GetByUserId(_currentUserService.UserId);
        
        var tasks = await _unitOfWork.Managers.GetManagerTasks(manager!.Id);
        
        var taskDto = _mapper.Map<ICollection<ManagerTaskDto>>(tasks);
        
        return new BaseResponse(taskDto);
    }
}