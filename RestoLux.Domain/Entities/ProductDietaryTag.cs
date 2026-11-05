namespace RestoLux.Domain.Entities;

public class ProductDietaryTag : BaseEntity
{
    public int ProductId { get; set; }
    public int DietaryTagId { get; set; }

    // Navigation
    public Product Product { get; set; } = null!;
    public DietaryTag DietaryTag { get; set; } = null!;
}
