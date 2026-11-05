namespace RestoLux.Domain.Entities;

public class ReservationTable : BaseEntity
{
    public int ReservationId { get; set; }
    public int DiningTableId { get; set; }

    // Navigation
    public Reservation Reservation { get; set; } = null!;
    public DiningTable DiningTable { get; set; } = null!;
}
