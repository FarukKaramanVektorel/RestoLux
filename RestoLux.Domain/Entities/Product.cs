namespace RestoLux.Domain.Entities;

/// <summary>
/// A menu product/item with full details.
/// </summary>
public class Product : BaseEntity
{
    public int CategoryId { get; set; }
    public int? TaxRuleId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Slug { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? PortionInfo { get; set; }
    public int? Calories { get; set; }
    public int? SpicyLevel { get; set; }
    public int? PreparationTimeMinutes { get; set; }
    public int SortOrder { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsFeatured { get; set; }
    public bool IsChefRecommended { get; set; }
    public bool IsPopular { get; set; }
    public bool IsNewItem { get; set; }

    // Navigation
    public MenuCategory Category { get; set; } = null!;
    public TaxRule? TaxRule { get; set; }
    public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
    public ICollection<ProductVariant> Variants { get; set; } = new List<ProductVariant>();
    public ICollection<ProductAllergen> ProductAllergens { get; set; } = new List<ProductAllergen>();
    public ICollection<ProductDietaryTag> ProductDietaryTags { get; set; } = new List<ProductDietaryTag>();
    public ICollection<ModifierGroup> ModifierGroups { get; set; } = new List<ModifierGroup>();
    public ICollection<BranchProductAvailability> BranchAvailabilities { get; set; } = new List<BranchProductAvailability>();
}
