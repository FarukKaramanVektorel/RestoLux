using RestoLux.Domain.Entities;

namespace RestoLux.Application.DTOs;

public record ModifierGroupDto(int Id, int ProductId, string Name, bool IsRequired, int MinSelections, int MaxSelections, int SortOrder, DateTime CreatedAt, DateTime UpdatedAt);
public record CreateModifierGroupDto(int ProductId, string Name, bool IsRequired = false, int MinSelections = 0, int MaxSelections = 1, int SortOrder = 0);
public record UpdateModifierGroupDto(int ProductId, string Name, bool IsRequired, int MinSelections, int MaxSelections, int SortOrder);

public static class ModifierGroupMappings
{
    public static ModifierGroupDto ToDto(this ModifierGroup e) => new(e.Id, e.ProductId, e.Name, e.IsRequired, e.MinSelections, e.MaxSelections, e.SortOrder, e.CreatedAt, e.UpdatedAt);
    public static ModifierGroup ToEntity(this CreateModifierGroupDto d) => new() { ProductId = d.ProductId, Name = d.Name, IsRequired = d.IsRequired, MinSelections = d.MinSelections, MaxSelections = d.MaxSelections, SortOrder = d.SortOrder };
    public static void Apply(this UpdateModifierGroupDto d, ModifierGroup e) { e.ProductId = d.ProductId; e.Name = d.Name; e.IsRequired = d.IsRequired; e.MinSelections = d.MinSelections; e.MaxSelections = d.MaxSelections; e.SortOrder = d.SortOrder; }
}

public record ModifierOptionDto(int Id, int ModifierGroupId, string Name, decimal PriceDifference, int SortOrder, bool IsDefault, bool IsActive, DateTime CreatedAt, DateTime UpdatedAt);
public record CreateModifierOptionDto(int ModifierGroupId, string Name, decimal PriceDifference = 0, int SortOrder = 0, bool IsDefault = false, bool IsActive = true);
public record UpdateModifierOptionDto(int ModifierGroupId, string Name, decimal PriceDifference, int SortOrder, bool IsDefault, bool IsActive);

public static class ModifierOptionMappings
{
    public static ModifierOptionDto ToDto(this ModifierOption e) => new(e.Id, e.ModifierGroupId, e.Name, e.PriceDifference, e.SortOrder, e.IsDefault, e.IsActive, e.CreatedAt, e.UpdatedAt);
    public static ModifierOption ToEntity(this CreateModifierOptionDto d) => new() { ModifierGroupId = d.ModifierGroupId, Name = d.Name, PriceDifference = d.PriceDifference, SortOrder = d.SortOrder, IsDefault = d.IsDefault, IsActive = d.IsActive };
    public static void Apply(this UpdateModifierOptionDto d, ModifierOption e) { e.ModifierGroupId = d.ModifierGroupId; e.Name = d.Name; e.PriceDifference = d.PriceDifference; e.SortOrder = d.SortOrder; e.IsDefault = d.IsDefault; e.IsActive = d.IsActive; }
}