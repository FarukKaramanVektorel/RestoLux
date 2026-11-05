namespace RestoLux.Domain.Entities;

public class Customer : BaseEntity
{
    public string? UserId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Notes { get; set; }
    public bool IsGuest { get; set; }
    public bool IsVip { get; set; }
    public int NoShowCount { get; set; }
    public int VisitCount { get; set; }
    public decimal TotalSpent { get; set; }

    public string FullName => $"{FirstName} {LastName}";

    // Navigation
    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    public ICollection<CustomerNote> CustomerNotes { get; set; } = new List<CustomerNote>();
    public ICollection<CustomerConsent> Consents { get; set; } = new List<CustomerConsent>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}
