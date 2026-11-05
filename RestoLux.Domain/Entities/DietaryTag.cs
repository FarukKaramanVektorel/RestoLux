namespace RestoLux.Domain.Entities;

public class DietaryTag : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Icon { get; set; }
    public string? CssClass { get; set; }
    public int SortOrder { get; set; }

    // Navigation
    public ICollection<ProductDietaryTag> ProductDietaryTags { get; set; } = new List<ProductDietaryTag>();
}
