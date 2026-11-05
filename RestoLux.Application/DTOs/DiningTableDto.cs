using RestoLux.Domain.Entities;
using RestoLux.Domain.Enums;

namespace RestoLux.Application.DTOs;

public record DiningTableDto(int Id, int DiningAreaId, string TableNumber, int MinCapacity, int MaxCapacity, TableStatus Status, double? PositionX, double? PositionY, string? Shape, bool IsActive, bool IsReservable, DateTime CreatedAt, DateTime UpdatedAt);
public record CreateDiningTableDto(int DiningAreaId, string TableNumber, int MinCapacity = 1, int MaxCapacity = 4, TableStatus Status = TableStatus.Available, double? PositionX = null, double? PositionY = null, string? Shape = null, bool IsActive = true, bool IsReservable = true);
public record UpdateDiningTableDto(int DiningAreaId, string TableNumber, int MinCapacity, int MaxCapacity, TableStatus Status, double? PositionX, double? PositionY, string? Shape, bool IsActive, bool IsReservable);

public static class DiningTableMappings
{
    public static DiningTableDto ToDto(this DiningTable e) => new(e.Id, e.DiningAreaId, e.TableNumber, e.MinCapacity, e.MaxCapacity, e.Status, e.PositionX, e.PositionY, e.Shape, e.IsActive, e.IsReservable, e.CreatedAt, e.UpdatedAt);
    public static DiningTable ToEntity(this CreateDiningTableDto d) => new() { DiningAreaId = d.DiningAreaId, TableNumber = d.TableNumber, MinCapacity = d.MinCapacity, MaxCapacity = d.MaxCapacity, Status = d.Status, PositionX = d.PositionX, PositionY = d.PositionY, Shape = d.Shape, IsActive = d.IsActive, IsReservable = d.IsReservable };
    public static void Apply(this UpdateDiningTableDto d, DiningTable e) { e.DiningAreaId = d.DiningAreaId; e.TableNumber = d.TableNumber; e.MinCapacity = d.MinCapacity; e.MaxCapacity = d.MaxCapacity; e.Status = d.Status; e.PositionX = d.PositionX; e.PositionY = d.PositionY; e.Shape = d.Shape; e.IsActive = d.IsActive; e.IsReservable = d.IsReservable; }
}