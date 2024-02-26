using System.Net;
using System.Net.Mail;
using System.Text;
using Microsoft.Extensions.Configuration;
using TaskManagerAPI.Application.Abstractions.Services;

namespace TaskManagerAPI.Infrastructure.Services;

public class MailService : IMailService
{
    private readonly IConfiguration _configuration;

    public MailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true)
    {
        MailMessage mail = new();
        mail.IsBodyHtml = isBodyHtml;
        mail.To.Add(to);
        mail.Subject = subject;
        mail.Body = body;
        mail.From = new(_configuration["mailSettings:Username"] ?? throw new InvalidOperationException());

        SmtpClient smtpClient = new();
        smtpClient.Credentials = new NetworkCredential(_configuration["mailSettings:Username"],
            _configuration["mailSettings:Password"]);
        smtpClient.Port=Convert.ToInt32(_configuration["mailSettings:Port"]);
        smtpClient.EnableSsl = true;
        smtpClient.Host = _configuration["mailSettings:Host"] ?? string.Empty;
        await smtpClient.SendMailAsync(mail);
    }

    public async Task SendPasswordResetMailAsync(string to,string userId, string resetToken)
    {
        StringBuilder mail = new();
        mail.AppendLine(
            "<br>Merhaba <br> Yeni şifre talebinde bulunduysanız aşağıdaki linkten şifrenizi yenileyebilirsiniz.<br><a target=\"_blank\" href=\"");
        mail.AppendLine(_configuration["AngularClientUrl"]);
        mail.AppendLine("/update-password/");
        mail.AppendLine(userId);
        mail.AppendLine("/");
        mail.AppendLine(resetToken);
        mail.AppendLine("\"> Yeni şifre talebi için tıklayınız...</a></strong><br><br><small>NOT: Eğer bu talep tarafınızca gerçekleştirilmemişse lütfen bu maili ciddiye almayınız. </small><br><br><hr><br>TASK MANAGER A.Ş<br> ");

        await SendMailAsync(to, "Şİfre Yenileme Talebi", mail.ToString(), true);
       
    }
}