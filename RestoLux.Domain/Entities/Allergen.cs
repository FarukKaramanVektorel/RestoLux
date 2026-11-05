namespace RestoLux.Domain.Entities;

public class Allergen : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Icon { get; set; }
    public int SortOrder { get; set; }

    // Navigation
    public ICollection<ProductAllergen> ProductAllergens { get; set; } = new List<ProductAllergen>();
}
