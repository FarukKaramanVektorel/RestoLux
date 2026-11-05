using RestoLux.Domain.Entities;

namespace RestoLux.Application.DTOs;

public record SpecialClosureDto(int Id, int BranchId, DateOnly Date, string? Reason, bool IsFullDay, TimeOnly? OpenTime, TimeOnly? CloseTime, DateTime CreatedAt, DateTime UpdatedAt);
public record CreateSpecialClosureDto(int BranchId, DateOnly Date, string? Reason, bool IsFullDay = true, TimeOnly? OpenTime = null, TimeOnly? CloseTime = null);
public record UpdateSpecialClosureDto(int BranchId, DateOnly Date, string? Reason, bool IsFullDay, TimeOnly? OpenTime, TimeOnly? CloseTime);

public static class SpecialClosureMappings
{
    public static SpecialClosureDto ToDto(this SpecialClosure e) => new(e.Id, e.BranchId, e.Date, e.Reason, e.IsFullDay, e.OpenTime, e.CloseTime, e.CreatedAt, e.UpdatedAt);
    public static SpecialClosure ToEntity(this CreateSpecialClosureDto d) => new() { BranchId = d.BranchId, Date = d.Date, Reason = d.Reason, IsFullDay = d.IsFullDay, OpenTime = d.OpenTime, CloseTime = d.CloseTime };
    public static void Apply(this UpdateSpecialClosureDto d, SpecialClosure e) { e.BranchId = d.BranchId; e.Date = d.Date; e.Reason = d.Reason; e.IsFullDay = d.IsFullDay; e.OpenTime = d.OpenTime; e.CloseTime = d.CloseTime; }
}