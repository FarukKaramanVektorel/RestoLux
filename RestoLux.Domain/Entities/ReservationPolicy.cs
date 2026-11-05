namespace RestoLux.Domain.Entities;

public class ReservationPolicy : BaseEntity
{
    public int BranchId { get; set; }
    public int MinGuests { get; set; } = 1;
    public int MaxGuests { get; set; } = 20;
    public int SlotDurationMinutes { get; set; } = 30;
    public int DefaultDurationMinutes { get; set; } = 120;
    public int MinAdvanceHours { get; set; } = 1;
    public int MaxAdvanceDays { get; set; } = 30;
    public string? CancellationPolicyText { get; set; }
    public int CancellationDeadlineHours { get; set; } = 24;
    public bool AllowWaitlist { get; set; } = true;
    public bool RequireConfirmation { get; set; } = true;

    // Navigation
    public Branch Branch { get; set; } = null!;
}
