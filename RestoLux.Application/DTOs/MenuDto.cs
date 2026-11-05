using RestoLux.Domain.Entities;

namespace RestoLux.Application.DTOs;

public record MenuDto(
    int Id, int BranchId, string Name, string? Description, int SortOrder, bool IsActive, bool IsFeatured,
    DateOnly? ValidFrom, DateOnly? ValidTo, DateTime CreatedAt, DateTime UpdatedAt);

public record CreateMenuDto(
    int BranchId, string Name, string? Description, int SortOrder = 0, bool IsActive = true, bool IsFeatured = false,
    DateOnly? ValidFrom = null, DateOnly? ValidTo = null);

public record UpdateMenuDto(
    int BranchId, string Name, string? Description, int SortOrder, bool IsActive, bool IsFeatured,
    DateOnly? ValidFrom, DateOnly? ValidTo);

public static class MenuMappings
{
    public static MenuDto ToDto(this Menu e) => new(
        e.Id, e.BranchId, e.Name, e.Description, e.SortOrder, e.IsActive, e.IsFeatured, e.ValidFrom, e.ValidTo,
        e.CreatedAt, e.UpdatedAt);

    public static Menu ToEntity(this CreateMenuDto d) => new()
    {
        BranchId = d.BranchId, Name = d.Name, Description = d.Description, SortOrder = d.SortOrder,
        IsActive = d.IsActive, IsFeatured = d.IsFeatured, ValidFrom = d.ValidFrom, ValidTo = d.ValidTo
    };

    public static void Apply(this UpdateMenuDto d, Menu e)
    {
        e.BranchId = d.BranchId; e.Name = d.Name; e.Description = d.Description; e.SortOrder = d.SortOrder;
        e.IsActive = d.IsActive; e.IsFeatured = d.IsFeatured; e.ValidFrom = d.ValidFrom; e.ValidTo = d.ValidTo;
    }
}