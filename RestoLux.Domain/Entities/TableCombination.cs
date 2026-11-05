namespace RestoLux.Domain.Entities;

public class TableCombination : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int CombinedCapacity { get; set; }
    public bool IsActive { get; set; }

    // Navigation
    public ICollection<DiningTable> Tables { get; set; } = new List<DiningTable>();
}
