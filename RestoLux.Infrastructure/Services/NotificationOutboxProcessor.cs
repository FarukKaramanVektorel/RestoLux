using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RestoLux.Infrastructure.Data;

namespace RestoLux.Infrastructure.Services;

public class NotificationOutboxProcessor : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<NotificationOutboxProcessor> _logger;

    public NotificationOutboxProcessor(IServiceScopeFactory scopeFactory, ILogger<NotificationOutboxProcessor> logger)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = _scopeFactory.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var pending = await db.NotificationOutboxes
                    .Where(n => n.Status == Domain.Enums.NotificationStatus.Pending && (n.NextRetryAt == null || n.NextRetryAt <= DateTime.UtcNow))
                    .OrderBy(n => n.CreatedAt)
                    .Take(20)
                    .ToListAsync(stoppingToken);

                foreach (var n in pending)
                {
                    try
                    {
                        // Placeholder: actual email/SMS sending via IEmailService
                        _logger.LogInformation("Sending notification {Id} to {Recipient}", n.Id, n.Recipient);
                        n.Status = Domain.Enums.NotificationStatus.Sent;
                        n.SentAt = DateTime.UtcNow;
                    }
                    catch (Exception ex)
                    {
                        n.RetryCount++;
                        n.ErrorMessage = ex.Message;
                        if (n.RetryCount >= n.MaxRetries)
                            n.Status = Domain.Enums.NotificationStatus.Failed;
                        else
                            n.NextRetryAt = DateTime.UtcNow.AddMinutes(Math.Pow(2, n.RetryCount));
                    }
                }
                if (pending.Count > 0)
                    await db.SaveChangesAsync(stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Outbox processing error");
            }

            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
        }
    }
}