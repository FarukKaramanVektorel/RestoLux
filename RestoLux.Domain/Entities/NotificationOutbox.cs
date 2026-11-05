using RestoLux.Domain.Enums;

namespace RestoLux.Domain.Entities;

/// <summary>
/// Outbox pattern for reliable notification delivery.
/// BackgroundService processes pending entries with exponential backoff.
/// </summary>
public class NotificationOutbox : BaseEntity
{
    public string Recipient { get; set; } = string.Empty;
    public string? Subject { get; set; }
    public string Body { get; set; } = string.Empty;
    public NotificationType Type { get; set; }
    public NotificationStatus Status { get; set; } = NotificationStatus.Pending;
    public int RetryCount { get; set; }
    public int MaxRetries { get; set; } = 5;
    public DateTime? NextRetryAt { get; set; }
    public DateTime? SentAt { get; set; }
    public string? ErrorMessage { get; set; }
    public string? ReferenceType { get; set; }
    public int? ReferenceId { get; set; }
}
