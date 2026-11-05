namespace RestoLux.Domain.Entities;

public class WaitlistEntry : BaseEntity
{
    public int BranchId { get; set; }
    public int CustomerId { get; set; }
    public DateOnly DesiredDate { get; set; }
    public TimeOnly? PreferredTime { get; set; }
    public int GuestCount { get; set; }
    public bool IsNotified { get; set; }
    public bool IsConverted { get; set; }
    public int? ConvertedReservationId { get; set; }

    // Navigation
    public Branch Branch { get; set; } = null!;
    public Customer Customer { get; set; } = null!;
}
