using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.NotificationModule;

[NotMapped]
public class Email
{
    public string EmailAddress { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
}