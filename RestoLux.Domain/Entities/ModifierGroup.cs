namespace RestoLux.Domain.Entities;

public class ModifierGroup : BaseEntity
{
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsRequired { get; set; }
    public int MinSelections { get; set; }
    public int MaxSelections { get; set; } = 1;
    public int SortOrder { get; set; }

    // Navigation
    public Product Product { get; set; } = null!;
    public ICollection<ModifierOption> Options { get; set; } = new List<ModifierOption>();
}
