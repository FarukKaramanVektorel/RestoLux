using RestoLux.Domain.Entities;

namespace RestoLux.Application.DTOs;

public record OpeningHourDto(int Id, int BranchId, DayOfWeek DayOfWeek, TimeOnly OpenTime, TimeOnly CloseTime, bool IsClosed, DateTime CreatedAt, DateTime UpdatedAt);
public record CreateOpeningHourDto(int BranchId, DayOfWeek DayOfWeek, TimeOnly OpenTime, TimeOnly CloseTime, bool IsClosed = false);
public record UpdateOpeningHourDto(int BranchId, DayOfWeek DayOfWeek, TimeOnly OpenTime, TimeOnly CloseTime, bool IsClosed);

public static class OpeningHourMappings
{
    public static OpeningHourDto ToDto(this OpeningHour e) => new(e.Id, e.BranchId, e.DayOfWeek, e.OpenTime, e.CloseTime, e.IsClosed, e.CreatedAt, e.UpdatedAt);
    public static OpeningHour ToEntity(this CreateOpeningHourDto d) => new() { BranchId = d.BranchId, DayOfWeek = d.DayOfWeek, OpenTime = d.OpenTime, CloseTime = d.CloseTime, IsClosed = d.IsClosed };
    public static void Apply(this UpdateOpeningHourDto d, OpeningHour e) { e.BranchId = d.BranchId; e.DayOfWeek = d.DayOfWeek; e.OpenTime = d.OpenTime; e.CloseTime = d.CloseTime; e.IsClosed = d.IsClosed; }
}