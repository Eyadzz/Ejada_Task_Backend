using Application.Contracts.Services;

namespace Application.Features.Tasks.Commands;

public record MarkTaskCompleted(int Id) : IRequest<BaseResponse>;

public class MarkTaskCompletedHandler : IRequestHandler<MarkTaskCompleted, BaseResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;

    public MarkTaskCompletedHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
    {
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
    }

    public async Task<BaseResponse> Handle(MarkTaskCompleted request, CancellationToken cancellationToken)
    {
        var task = await _unitOfWork.Tasks.GetAsync(request.Id);
        if (task == null)
            return Responses.NotFound("Task");
        
        var employee = await _unitOfWork.Employees.GetByUserId(_currentUserService.UserId);

        if (task.AssignedToId != employee!.Id)
            return Responses.Unauthorized();

        task.SubmissionDate = DateTime.UtcNow;
        
        await _unitOfWork.Save();

        return Responses.Success();
    }
}