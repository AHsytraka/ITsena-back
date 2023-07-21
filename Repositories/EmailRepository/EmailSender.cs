using System.Net;
using System.Net.Mail;

namespace ITsena_back.Services;

public class EmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string message)
    {
        var client = new SmtpClient("smtp.gmail.com", 587)
        {
            EnableSsl = true,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential("ahsytraka@gmail.com", "llnvxlqplcgfhjkn")
        };
 
        return client.SendMailAsync(
            new MailMessage(from: "ahsytraka@gmail.com",
                            to: email,
                            subject,
                            message
            )
        );
    }
}