namespace RestoLux.Domain.Entities;

public class BranchProductAvailability : BaseEntity
{
    public int BranchId { get; set; }
    public int ProductId { get; set; }
    public bool IsAvailable { get; set; } = true;
    public decimal? OverridePrice { get; set; }

    // Navigation
    public Branch Branch { get; set; } = null!;
    public Product Product { get; set; } = null!;
}
