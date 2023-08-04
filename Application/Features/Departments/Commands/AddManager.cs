using Application.Contracts.Authentication;
using Application.Features.Notifications;
using Domain.NotificationModule;
using Domain.UserModule;

namespace Application.Features.Departments.Commands;

public record AddManager(string Name, string Email, string PhoneNumber, DateTime BirthDate) : IRequest<BaseResponse>;

public class AddManagerHandler : IRequestHandler<AddManager, BaseResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;
    private readonly IPasswordManager _passwordManager;

    public AddManagerHandler(IUnitOfWork unitOfWork, IMediator mediator, IPasswordManager passwordManager)
    {
        _unitOfWork = unitOfWork;
        _mediator = mediator;
        _passwordManager = passwordManager;
    }
    
    public async Task<BaseResponse> Handle(AddManager request, CancellationToken cancellationToken)
    {
        var emailExists = await _unitOfWork.Users.EmailExists(request.Email);
        if (emailExists)
            return Responses.AlreadyExist("Email");
        
        var phoneNumberExists = await _unitOfWork.Users.PhoneNumberExists(request.PhoneNumber);
        if (phoneNumberExists)
            return Responses.AlreadyExist("Phone Number");

        var generatedPassword = await AddManager(request);
        
        await SendRegistrationEmail(request.Email, generatedPassword);
        
        return Responses.Success(generatedPassword);
    }

    private async Task<string> AddManager(AddManager request)
    {
        var generatedPassword = _passwordManager.GenerateRandomPassword();
        
        var employee = new Manager
        {
            User = new User {
                Name = request.Name,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                PasswordHash = _passwordManager.Hash(generatedPassword),
                RoleId = 3,
                BirthDate = request.BirthDate
            }
        };
        await _unitOfWork.Managers.AddAsync(employee);
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