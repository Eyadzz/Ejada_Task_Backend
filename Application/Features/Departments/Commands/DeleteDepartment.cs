namespace Application.Features.Departments.Commands;

public record DeleteDepartment(int Id) : IRequest<BaseResponse>;

public class DeleteDepartmentHandler : IRequestHandler<DeleteDepartment, BaseResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDepartmentHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseResponse> Handle(DeleteDepartment request, CancellationToken cancellationToken)
    {
        var department = await _unitOfWork.Departments.GetAsync(request.Id);
        if (department is null)
            return Responses.NotFound("Department");

        _unitOfWork.Departments.Delete(department);
        await _unitOfWork.Save();

        return Responses.Success();
    }
}