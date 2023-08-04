using Application.Features.Users.Dto;

namespace Application.Features.Departments.Queries;

public record Managers() : IRequest<BaseResponse>;

public class ManagersHandler : IRequestHandler<Managers, BaseResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ManagersHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<BaseResponse> Handle(Managers request, CancellationToken cancellationToken)
    {
        var managers = await _unitOfWork.Managers.GetManagersDetails();
        
        var managersDto = _mapper.Map<List<ManagerDto>>(managers);
        
        return Responses.Success(managersDto);
    }
}