namespace RestoLux.Domain.Entities;

/// <summary>
/// Represents a menu (e.g., Main Menu, Seasonal Menu, Chef's Specials).
/// </summary>
public class Menu : BaseEntity
{
    public int BranchId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int SortOrder { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsFeatured { get; set; }
    public DateOnly? ValidFrom { get; set; }
    public DateOnly? ValidTo { get; set; }

    // Navigation
    public Branch Branch { get; set; } = null!;
    public ICollection<MenuCategory> Categories { get; set; } = new List<MenuCategory>();
}
