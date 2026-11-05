using RestoLux.Domain.Enums;

namespace RestoLux.Domain.Entities;

public class NotificationTemplate : BaseEntity
{
    public string TemplateName { get; set; } = string.Empty;
    public string? Subject { get; set; }
    public string Body { get; set; } = string.Empty;
    public NotificationType Type { get; set; }
    public string Culture { get; set; } = "tr";
    public bool IsActive { get; set; } = true;
}
