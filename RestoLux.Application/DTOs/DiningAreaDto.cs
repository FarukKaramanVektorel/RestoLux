using RestoLux.Domain.Entities;
using RestoLux.Domain.Enums;

namespace RestoLux.Application.DTOs;

public record DiningAreaDto(int Id, int BranchId, string Name, DiningAreaType AreaType, int Capacity, int SortOrder, bool IsActive, bool IsReservable, DateTime CreatedAt, DateTime UpdatedAt);
public record CreateDiningAreaDto(int BranchId, string Name, DiningAreaType AreaType, int Capacity, int SortOrder = 0, bool IsActive = true, bool IsReservable = true);
public record UpdateDiningAreaDto(int BranchId, string Name, DiningAreaType AreaType, int Capacity, int SortOrder, bool IsActive, bool IsReservable);

public static class DiningAreaMappings
{
    public static DiningAreaDto ToDto(this DiningArea e) => new(e.Id, e.BranchId, e.Name, e.AreaType, e.Capacity, e.SortOrder, e.IsActive, e.IsReservable, e.CreatedAt, e.UpdatedAt);
    public static DiningArea ToEntity(this CreateDiningAreaDto d) => new() { BranchId = d.BranchId, Name = d.Name, AreaType = d.AreaType, Capacity = d.Capacity, SortOrder = d.SortOrder, IsActive = d.IsActive, IsReservable = d.IsReservable };
    public static void Apply(this UpdateDiningAreaDto d, DiningArea e) { e.BranchId = d.BranchId; e.Name = d.Name; e.AreaType = d.AreaType; e.Capacity = d.Capacity; e.SortOrder = d.SortOrder; e.IsActive = d.IsActive; e.IsReservable = d.IsReservable; }
}