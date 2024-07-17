using PeakPerformance.Application.Dtos.Emails;
using PeakPerformance.Application.Interfaces;
using System.Net;
using System.Net.Mail;

namespace PeakPerformance.Application.Services;

public class EmailService : IEmailService
{
    private readonly string _smtpServer;
    private readonly int _smtpPort;
    private readonly string _smtpUsername;
    private readonly string _smtpPassword;

    public EmailService(string smtpServer, int smtpPort, string smtpUsername, string smtpPassword)
    {
        _smtpServer = smtpServer;
        _smtpPort = smtpPort;
        _smtpUsername = smtpUsername;
        _smtpPassword = smtpPassword;
    }

    public async Task SendEmailAsync(EmailDto email)
    {
        try
        {
            using (var client = new SmtpClient(_smtpServer, _smtpPort))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(_smtpUsername, _smtpPassword);
                client.EnableSsl = true;

                var message = new MailMessage
                {
                    From = new MailAddress(_smtpUsername),
                    Subject = email.Subject,
                    Body = email.Body,
                    IsBodyHtml = true
                };
                message.To.Add(email.ToEmail);

                await client.SendMailAsync(message);
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}