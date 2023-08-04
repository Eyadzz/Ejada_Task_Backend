using Application.Contracts.Mailing;
using Domain.NotificationModule;
using Microsoft.Extensions.Logging;

namespace Application.Features.Notifications;

public record SendEmail(Email Email) : IRequest<bool>;

public class SendEmailHandler : IRequestHandler<SendEmail, bool>
{
    private readonly IMailSender _mailSender;
    private readonly ILogger<SendEmailHandler> _logger;

    public SendEmailHandler(IMailSender mailSender, ILogger<SendEmailHandler> logger)
    {
        _mailSender = mailSender;
        _logger = logger;
    }
    
    public async Task<bool> Handle(SendEmail request, CancellationToken cancellationToken)
    {
        try
        {
            await _mailSender.Send(request.Email);
            _logger.LogInformation("Sent Email to {EmailAddress}", request.Email.EmailAddress);
        }
        catch (Exception e)
        {
            _logger.LogError("Could not Send Email");
            throw;
        }
        
        return true;
    }
}