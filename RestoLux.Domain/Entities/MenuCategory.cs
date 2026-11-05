namespace RestoLux.Domain.Entities;

/// <summary>
/// Menu category with support for subcategories.
/// </summary>
public class MenuCategory : BaseEntity
{
    public int MenuId { get; set; }
    public int? ParentCategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Slug { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public int SortOrder { get; set; }
    public bool IsActive { get; set; } = true;

    // Navigation
    public Menu Menu { get; set; } = null!;
    public MenuCategory? ParentCategory { get; set; }
    public ICollection<MenuCategory> SubCategories { get; set; } = new List<MenuCategory>();
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
