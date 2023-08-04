using Application.Contracts.Services;
using Application.Mappings;
using Task = Domain.TaskModule.Task;

namespace Application.Features.Tasks.Commands;

public class UpdateTask : IRequest<BaseResponse>, IMapFrom<Task>
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int? AssignedToId { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateTask, Task>().ReverseMap();
    }
}

public class UpdateTaskHandler : IRequestHandler<UpdateTask, BaseResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;
    private readonly IMapper _mapper;

    public UpdateTaskHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
        _mapper = mapper;
    }

    public async Task<BaseResponse> Handle(UpdateTask request, CancellationToken cancellationToken)
    {
        var task = await _unitOfWork.Tasks.GetAsync(request.Id);
        if (task == null)
            return Responses.NotFound("Task");

        var manager = await _unitOfWork.Managers.GetByUserId(_currentUserService.UserId);
        
        if (task.AssignedById != manager!.Id || task.SubmissionDate != null)
            return Responses.Unauthorized();

        if (request.AssignedToId != null)
        {
            var employee = await _unitOfWork.Employees.GetAsync((int) request.AssignedToId);
            if (employee == null)
                return Responses.NotFound("Employee");
        }

        _mapper.Map(request, task);
        
        await _unitOfWork.Save();

        return Responses.Success();
    }
}