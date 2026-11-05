namespace RestoLux.Domain.Entities;

/// <summary>
/// Special closure dates (holidays, events, etc.)
/// </summary>
public class SpecialClosure : BaseEntity
{
    public int BranchId { get; set; }
    public DateOnly Date { get; set; }
    public string? Reason { get; set; }
    public bool IsFullDay { get; set; } = true;
    public TimeOnly? OpenTime { get; set; }
    public TimeOnly? CloseTime { get; set; }

    // Navigation
    public Branch Branch { get; set; } = null!;
}
