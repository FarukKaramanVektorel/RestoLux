namespace RestoLux.Domain.Entities;

public class ProductAllergen : BaseEntity
{
    public int ProductId { get; set; }
    public int AllergenId { get; set; }

    // Navigation
    public Product Product { get; set; } = null!;
    public Allergen Allergen { get; set; } = null!;
}
