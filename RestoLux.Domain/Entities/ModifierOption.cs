namespace RestoLux.Domain.Entities;

public class ModifierOption : BaseEntity
{
    public int ModifierGroupId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal PriceDifference { get; set; }
    public int SortOrder { get; set; }
    public bool IsDefault { get; set; }
    public bool IsActive { get; set; } = true;

    // Navigation
    public ModifierGroup ModifierGroup { get; set; } = null!;
}
