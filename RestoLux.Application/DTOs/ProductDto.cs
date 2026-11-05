using RestoLux.Domain.Entities;

namespace RestoLux.Application.DTOs;

public record ProductDto(
    int Id, int CategoryId, int? TaxRuleId, string Name, string? Slug, string? Description, decimal Price,
    string? PortionInfo, int? Calories, int? SpicyLevel, int? PreparationTimeMinutes, int SortOrder, bool IsActive,
    bool IsFeatured, bool IsChefRecommended, bool IsPopular, bool IsNewItem, DateTime CreatedAt, DateTime UpdatedAt);

public record CreateProductDto(
    int CategoryId, int? TaxRuleId, string Name, string? Slug, string? Description, decimal Price,
    string? PortionInfo, int? Calories, int? SpicyLevel, int? PreparationTimeMinutes, int SortOrder = 0,
    bool IsActive = true, bool IsFeatured = false, bool IsChefRecommended = false, bool IsPopular = false,
    bool IsNewItem = false);

public record UpdateProductDto(
    int CategoryId, int? TaxRuleId, string Name, string? Slug, string? Description, decimal Price,
    string? PortionInfo, int? Calories, int? SpicyLevel, int? PreparationTimeMinutes, int SortOrder, bool IsActive,
    bool IsFeatured, bool IsChefRecommended, bool IsPopular, bool IsNewItem);

public static class ProductMappings
{
    public static ProductDto ToDto(this Product e) => new(
        e.Id, e.CategoryId, e.TaxRuleId, e.Name, e.Slug, e.Description, e.Price, e.PortionInfo, e.Calories,
        e.SpicyLevel, e.PreparationTimeMinutes, e.SortOrder, e.IsActive, e.IsFeatured, e.IsChefRecommended,
        e.IsPopular, e.IsNewItem, e.CreatedAt, e.UpdatedAt);

    public static Product ToEntity(this CreateProductDto d) => new()
    {
        CategoryId = d.CategoryId, TaxRuleId = d.TaxRuleId, Name = d.Name, Slug = d.Slug, Description = d.Description,
        Price = d.Price, PortionInfo = d.PortionInfo, Calories = d.Calories, SpicyLevel = d.SpicyLevel,
        PreparationTimeMinutes = d.PreparationTimeMinutes, SortOrder = d.SortOrder, IsActive = d.IsActive,
        IsFeatured = d.IsFeatured, IsChefRecommended = d.IsChefRecommended, IsPopular = d.IsPopular, IsNewItem = d.IsNewItem
    };

    public static void Apply(this UpdateProductDto d, Product e)
    {
        e.CategoryId = d.CategoryId; e.TaxRuleId = d.TaxRuleId; e.Name = d.Name; e.Slug = d.Slug;
        e.Description = d.Description; e.Price = d.Price; e.PortionInfo = d.PortionInfo; e.Calories = d.Calories;
        e.SpicyLevel = d.SpicyLevel; e.PreparationTimeMinutes = d.PreparationTimeMinutes; e.SortOrder = d.SortOrder;
        e.IsActive = d.IsActive; e.IsFeatured = d.IsFeatured; e.IsChefRecommended = d.IsChefRecommended;
        e.IsPopular = d.IsPopular; e.IsNewItem = d.IsNewItem;
    }
}