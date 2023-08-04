using Application.Contracts.Services;

namespace Application.Features.Departments.Commands;

public record DeleteEmployee(int Id) : IRequest<BaseResponse>;

public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployee, BaseResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;

    public DeleteEmployeeHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
    {
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
    }

    public async Task<BaseResponse> Handle(DeleteEmployee request, CancellationToken cancellationToken)
    {
        var employee = await _unitOfWork.Employees.EmployeeDetails(request.Id);
        if (employee == null)
            return Responses.NotFound("Employee");
        
        var manager = await _unitOfWork.Managers.GetByUserId(_currentUserService.UserId);

        if (employee.DepartmentId != manager!.DepartmentId)
            return Responses.Unauthorized();

        _unitOfWork.Users.Delete(employee.User);

        await _unitOfWork.Save();

        return Responses.Success();
    }
}