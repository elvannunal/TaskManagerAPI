namespace TaskManagerAPI.Application.Abstractions.Services;

public interface IMailService
{
    Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true);

    Task SendPasswordResetMailAsync(string to,string userId, string resetToken);
}