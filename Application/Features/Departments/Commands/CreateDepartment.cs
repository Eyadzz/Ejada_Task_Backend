using Domain.DepartmentModule;
using Domain.UserModule;

namespace Application.Features.Departments.Commands;

public record CreateDepartment(string Name, int? ManagerId) : IRequest<BaseResponse>;

public class CreateDepartmentHandler : IRequestHandler<CreateDepartment, BaseResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateDepartmentHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<BaseResponse> Handle(CreateDepartment request, CancellationToken cancellationToken)
    {
        Manager? manager = null;
        
        if (request.ManagerId is not null)
        {
            manager = await _unitOfWork.Managers.GetAsync((int) request.ManagerId);
            if (manager is null)
                return Responses.NotFound("Manager");
        }

        try
        {
            await _unitOfWork.BeginTransaction();
            
            var department = new Department
            {
                Name = request.Name,
                ManagerId = request.ManagerId
            };

            await _unitOfWork.Departments.AddAsync(department);
            await _unitOfWork.Save();
            
            manager!.DepartmentId = department.Id;
            await _unitOfWork.Save();
            
            await _unitOfWork.Commit();
        }
        catch (Exception ex)
        {
            await _unitOfWork.Rollback();

            throw;
        }
        
        return Responses.Success();
    }
}