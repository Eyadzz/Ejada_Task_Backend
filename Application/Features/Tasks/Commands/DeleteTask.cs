using Application.Contracts.Services;

namespace Application.Features.Tasks.Commands;

public record DeleteTask(int Id) : IRequest<BaseResponse>;

public class DeleteTaskHandler : IRequestHandler<DeleteTask, BaseResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;

    public DeleteTaskHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
    {
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
    }

    public async Task<BaseResponse> Handle(DeleteTask request, CancellationToken cancellationToken)
    {
        var task = await _unitOfWork.Tasks.GetAsync(request.Id);
        if (task == null)
            return Responses.NotFound("Task");
        
        var manager = await _unitOfWork.Managers.GetByUserId(_currentUserService.UserId);

        if (task.AssignedById != manager!.Id)
            return Responses.Unauthorized();
        
        _unitOfWork.Tasks.Delete(task);
        await _unitOfWork.Save();

        return Responses.Success();
    }
}