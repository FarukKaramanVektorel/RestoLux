using RestoLux.Domain.Entities;

namespace RestoLux.Application.DTOs;

public record DietaryTagDto(int Id, string Name, string? Icon, string? CssClass, int SortOrder, DateTime CreatedAt, DateTime UpdatedAt);
public record CreateDietaryTagDto(string Name, string? Icon, string? CssClass, int SortOrder = 0);
public record UpdateDietaryTagDto(string Name, string? Icon, string? CssClass, int SortOrder);

public static class DietaryTagMappings
{
    public static DietaryTagDto ToDto(this DietaryTag e) => new(e.Id, e.Name, e.Icon, e.CssClass, e.SortOrder, e.CreatedAt, e.UpdatedAt);
    public static DietaryTag ToEntity(this CreateDietaryTagDto d) => new() { Name = d.Name, Icon = d.Icon, CssClass = d.CssClass, SortOrder = d.SortOrder };
    public static void Apply(this UpdateDietaryTagDto d, DietaryTag e) { e.Name = d.Name; e.Icon = d.Icon; e.CssClass = d.CssClass; e.SortOrder = d.SortOrder; }
}