namespace RestoLux.Domain.Interfaces;

public interface IEmailService
{
    Task<bool> SendEmailAsync(string to, string subject, string htmlBody, CancellationToken cancellationToken = default);
}
