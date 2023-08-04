using Application.Contracts.Authentication;
using Application.Contracts.Services;
using Application.Features.Notifications;
using Domain.NotificationModule;
using Domain.UserModule;

namespace Application.Features.Departments.Commands;

public record AddEmployee(string Name, string Email, string PhoneNumber, DateTime BirthDate) : IRequest<BaseResponse>;

public class AddEmployeeHandler : IRequestHandler<AddEmployee, BaseResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;
    private readonly IPasswordManager _passwordManager;
    private readonly ICurrentUserService _currentUserService;

    public AddEmployeeHandler(IUnitOfWork unitOfWork, IMediator mediator, IPasswordManager passwordManager, ICurrentUserService currentUserService)
    {
        _unitOfWork = unitOfWork;
        _mediator = mediator;
        _passwordManager = passwordManager;
        _currentUserService = currentUserService;
    }
    
    public async Task<BaseResponse> Handle(AddEmployee request, CancellationToken cancellationToken)
    {
        var emailExists = await _unitOfWork.Users.EmailExists(request.Email);
        if (emailExists)
            return Responses.AlreadyExist("Email");
        
        var phoneNumberExists = await _unitOfWork.Users.PhoneNumberExists(request.PhoneNumber);
        if (phoneNumberExists)
            return Responses.AlreadyExist("Phone Number");

        var generatedPassword = await AddEmployee(request);
        
        await SendRegistrationEmail(request.Email, generatedPassword);
        
        return Responses.Success(generatedPassword);
    }
    private async Task<string> AddEmployee(AddEmployee request)
    {
        var manager = await _unitOfWork.Managers.GetByUserId(_currentUserService.UserId);
        
        var generatedPassword = _passwordManager.GenerateRandomPassword();
        
        var employee = new Employee
        {
            DepartmentId = manager!.DepartmentId,
            User = new User {
                Name = request.Name,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                PasswordHash = _passwordManager.Hash(generatedPassword),
                RoleId = 2,
                BirthDate = request.BirthDate
            }
        };
        await _unitOfWork.Employees.AddAsync(employee);
        await _unitOfWork.Save();

        return generatedPassword;
    }
    
    private async Task SendRegistrationEmail(string newUserEmailAddress, string generatedPassword)
    {
        
        var email = new Email
        {
            EmailAddress = newUserEmailAddress,
            Subject = "Account Password",
            Body = generatedPassword
        };
        
        await _mediator.Send(new SendEmail(email));
    }
}