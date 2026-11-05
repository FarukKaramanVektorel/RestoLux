using RestoLux.Domain.Enums;

namespace RestoLux.Domain.Entities;

public class CustomerConsent : BaseEntity
{
    public int CustomerId { get; set; }
    public ConsentType ConsentType { get; set; }
    public bool IsGranted { get; set; }
    public DateTime? GrantedAt { get; set; }
    public DateTime? RevokedAt { get; set; }
    public string? IpAddress { get; set; }

    // Navigation
    public Customer Customer { get; set; } = null!;
}
