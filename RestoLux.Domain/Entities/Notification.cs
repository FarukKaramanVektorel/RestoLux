using RestoLux.Domain.Enums;

namespace RestoLux.Domain.Entities;

public class Notification : BaseEntity
{
    public int? BranchId { get; set; }
    public string? UserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public NotificationType Type { get; set; }
    public bool IsRead { get; set; }
    public DateTime? ReadAt { get; set; }
    public string? Link { get; set; }
}
