using Application.Features.Departments.Dto;

namespace Application.Features.Departments.Queries;

public record Departments() : IRequest<BaseResponse>;


public class DepartmentsHandler : IRequestHandler<Departments, BaseResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DepartmentsHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse> Handle(Departments request, CancellationToken cancellationToken)
    {
        var departments = _mapper.Map<List<DepartmentDto>>(await _unitOfWork.Departments.GetAllWithManagers());
        
        return Responses.Success(departments);
    }
}