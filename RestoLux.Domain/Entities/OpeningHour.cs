using RestoLux.Domain.Enums;

namespace RestoLux.Domain.Entities;

/// <summary>
/// Regular opening hours for a branch.
/// </summary>
public class OpeningHour : BaseEntity
{
    public int BranchId { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public TimeOnly OpenTime { get; set; }
    public TimeOnly CloseTime { get; set; }
    public bool IsClosed { get; set; }

    // Navigation
    public Branch Branch { get; set; } = null!;
}
