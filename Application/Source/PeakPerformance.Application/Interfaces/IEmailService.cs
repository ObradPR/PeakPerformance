using PeakPerformance.Application.Dtos.Emails;

namespace PeakPerformance.Application.Interfaces;

public interface IEmailService
{
    Task SendEmailAsync(EmailDto email);
}