using Application.Contracts.Services;
using Application.Mappings;
using Task = Domain.TaskModule.Task;

namespace Application.Features.Tasks.Commands;

public class CreateTask : IRequest<BaseResponse>, IMapFrom<Task>
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int? AssignedToId { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateTask, Task>()
            .ReverseMap();
    }
}

public class CreateTaskHandler : IRequestHandler<CreateTask, BaseResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;
    private readonly IMapper _mapper;

    public CreateTaskHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
        _mapper = mapper;
    }

    public async Task<BaseResponse> Handle(CreateTask request, CancellationToken cancellationToken)
    {
        if (request.AssignedToId != null)
        {
            var employee = await _unitOfWork.Employees.GetAsync((int) request.AssignedToId);
            if (employee == null)
                return Responses.NotFound("Employee");
        }
        
        var manager = await _unitOfWork.Managers.GetByUserId(_currentUserService.UserId);
        
        var task = _mapper.Map<Task>(request);
        task.AssignedById = manager!.Id;

        await _unitOfWork.Tasks.AddAsync(task);
        await _unitOfWork.Save();

        return Responses.Success();
    }
}