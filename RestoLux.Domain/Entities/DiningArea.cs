using RestoLux.Domain.Enums;

namespace RestoLux.Domain.Entities;

public class DiningArea : BaseEntity
{
    public int BranchId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DiningAreaType AreaType { get; set; }
    public int Capacity { get; set; }
    public int SortOrder { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsReservable { get; set; } = true;

    // Navigation
    public Branch Branch { get; set; } = null!;
    public ICollection<DiningTable> Tables { get; set; } = new List<DiningTable>();
}
