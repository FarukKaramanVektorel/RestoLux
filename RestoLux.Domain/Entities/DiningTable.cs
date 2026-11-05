using RestoLux.Domain.Enums;

namespace RestoLux.Domain.Entities;

public class DiningTable : BaseEntity
{
    public int DiningAreaId { get; set; }
    public string TableNumber { get; set; } = string.Empty;
    public int MinCapacity { get; set; } = 1;
    public int MaxCapacity { get; set; }
    public TableStatus Status { get; set; } = TableStatus.Available;
    public double? PositionX { get; set; }
    public double? PositionY { get; set; }
    public string? Shape { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsReservable { get; set; } = true;

    // Navigation
    public DiningArea DiningArea { get; set; } = null!;
    public ICollection<ReservationTable> ReservationTables { get; set; } = new List<ReservationTable>();
    public ICollection<TableCombination> TableCombinations { get; set; } = new List<TableCombination>();
}
