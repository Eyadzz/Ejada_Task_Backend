using Domain.NotificationModule;

namespace Application.Contracts.Mailing;

/// <summary>
/// Represents an interface for sending emails.
/// </summary>
public interface IMailSender
{
     /// <summary>
     /// Asynchronously sends an email using the provided <paramref name="email"/> object.
     /// </summary>
     /// <param name="email">An instance of the <see cref="Email"/> class containing email details like recipients, subject, body, etc.</param>
     /// <returns>A task representing the asynchronous operation of sending the email.</returns>
     Task Send(Email email);
}
