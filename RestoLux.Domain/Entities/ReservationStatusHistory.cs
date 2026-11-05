using RestoLux.Domain.Enums;

namespace RestoLux.Domain.Entities;

public class ReservationStatusHistory : BaseEntity
{
    public int ReservationId { get; set; }
    public ReservationStatus OldStatus { get; set; }
    public ReservationStatus NewStatus { get; set; }
    public string? ChangedByUserId { get; set; }
    public string? Notes { get; set; }

    // Navigation
    public Reservation Reservation { get; set; } = null!;
}
