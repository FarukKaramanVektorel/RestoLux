using RestoLux.Domain.Entities;

namespace RestoLux.Application.DTOs;

public record MenuCategoryDto(
    int Id, int MenuId, int? ParentCategoryId, string Name, string? Slug, string? Description, string? ImageUrl,
    int SortOrder, bool IsActive, DateTime CreatedAt, DateTime UpdatedAt);

public record CreateMenuCategoryDto(
    int MenuId, int? ParentCategoryId, string Name, string? Slug, string? Description, string? ImageUrl,
    int SortOrder = 0, bool IsActive = true);

public record UpdateMenuCategoryDto(
    int MenuId, int? ParentCategoryId, string Name, string? Slug, string? Description, string? ImageUrl,
    int SortOrder, bool IsActive);

public static class MenuCategoryMappings
{
    public static MenuCategoryDto ToDto(this MenuCategory e) => new(
        e.Id, e.MenuId, e.ParentCategoryId, e.Name, e.Slug, e.Description, e.ImageUrl, e.SortOrder, e.IsActive,
        e.CreatedAt, e.UpdatedAt);

    public static MenuCategory ToEntity(this CreateMenuCategoryDto d) => new()
    {
        MenuId = d.MenuId, ParentCategoryId = d.ParentCategoryId, Name = d.Name, Slug = d.Slug,
        Description = d.Description, ImageUrl = d.ImageUrl, SortOrder = d.SortOrder, IsActive = d.IsActive
    };

    public static void Apply(this UpdateMenuCategoryDto d, MenuCategory e)
    {
        e.MenuId = d.MenuId; e.ParentCategoryId = d.ParentCategoryId; e.Name = d.Name; e.Slug = d.Slug;
        e.Description = d.Description; e.ImageUrl = d.ImageUrl; e.SortOrder = d.SortOrder; e.IsActive = d.IsActive;
    }
}