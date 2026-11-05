namespace RestoLux.Domain.Entities;

public class CustomerNote : BaseEntity
{
    public int CustomerId { get; set; }
    public string Note { get; set; } = string.Empty;
    public string? CreatedByUserId { get; set; }

    // Navigation
    public Customer Customer { get; set; } = null!;
}
