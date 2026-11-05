using RestoLux.Domain.Enums;

namespace RestoLux.Domain.Entities;

public class Reservation : BaseEntity
{
    public int BranchId { get; set; }
    public int CustomerId { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public int GuestCount { get; set; }
    public ReservationStatus Status { get; set; } = ReservationStatus.Pending;
    public DiningAreaType? PreferredArea { get; set; }
    public string? SpecialRequests { get; set; }
    public string? OccasionNotes { get; set; }
    public bool IsBirthday { get; set; }
    public string? Source { get; set; }
    public string? CancellationReason { get; set; }
    public string? ConfirmationCode { get; set; }

    // Navigation
    public Branch Branch { get; set; } = null!;
    public Customer Customer { get; set; } = null!;
    public ICollection<ReservationTable> ReservationTables { get; set; } = new List<ReservationTable>();
    public ICollection<ReservationStatusHistory> StatusHistory { get; set; } = new List<ReservationStatusHistory>();
}
