using Application.Contracts.Mailing;
using Domain.NotificationModule;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Infrastructure.Mailing;

public sealed class MailSender : IMailSender
{
    private readonly MailSettings _mailSettings;

    public MailSender(IOptions<MailSettings> mailSettings)
    {
        _mailSettings = mailSettings.Value;
    }
    
    public async Task Send(Email email)
    {
        var mimeMessage = new MimeMessage();
        mimeMessage.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Email));
        mimeMessage.To.Add(MailboxAddress.Parse(email.EmailAddress));
        mimeMessage.Subject = email.Subject;

        var htmlView = new TextPart("html") { Text = MailTemplate.GetMailTemplate(email.Body) };
        mimeMessage.Body = htmlView;
        
        using var smtp = new SmtpClient();
        smtp.CheckCertificateRevocation = false;
        await smtp.ConnectAsync(_mailSettings.Host, _mailSettings.Port,false);
        await smtp.AuthenticateAsync(_mailSettings.Email, _mailSettings.Password);
        await smtp.SendAsync(mimeMessage);
        await smtp.DisconnectAsync(true);
    }
    
}