using RestoLux.Domain.Entities;

namespace RestoLux.Application.DTOs;

public record ProductVariantDto(int Id, int ProductId, string Name, decimal PriceDifference, bool IsDefault, int SortOrder, bool IsActive, DateTime CreatedAt, DateTime UpdatedAt);
public record CreateProductVariantDto(int ProductId, string Name, decimal PriceDifference = 0, bool IsDefault = false, int SortOrder = 0, bool IsActive = true);
public record UpdateProductVariantDto(int ProductId, string Name, decimal PriceDifference, bool IsDefault, int SortOrder, bool IsActive);

public static class ProductVariantMappings
{
    public static ProductVariantDto ToDto(this ProductVariant e) => new(e.Id, e.ProductId, e.Name, e.PriceDifference, e.IsDefault, e.SortOrder, e.IsActive, e.CreatedAt, e.UpdatedAt);
    public static ProductVariant ToEntity(this CreateProductVariantDto d) => new() { ProductId = d.ProductId, Name = d.Name, PriceDifference = d.PriceDifference, IsDefault = d.IsDefault, SortOrder = d.SortOrder, IsActive = d.IsActive };
    public static void Apply(this UpdateProductVariantDto d, ProductVariant e) { e.ProductId = d.ProductId; e.Name = d.Name; e.PriceDifference = d.PriceDifference; e.IsDefault = d.IsDefault; e.SortOrder = d.SortOrder; e.IsActive = d.IsActive; }
}

public record ProductImageDto(int Id, int ProductId, string Url, string? AltText, int SortOrder, bool IsPrimary, DateTime CreatedAt, DateTime UpdatedAt);
public record CreateProductImageDto(int ProductId, string Url, string? AltText, int SortOrder = 0, bool IsPrimary = false);
public record UpdateProductImageDto(int ProductId, string Url, string? AltText, int SortOrder, bool IsPrimary);

public static class ProductImageMappings
{
    public static ProductImageDto ToDto(this ProductImage e) => new(e.Id, e.ProductId, e.Url, e.AltText, e.SortOrder, e.IsPrimary, e.CreatedAt, e.UpdatedAt);
    public static ProductImage ToEntity(this CreateProductImageDto d) => new() { ProductId = d.ProductId, Url = d.Url, AltText = d.AltText, SortOrder = d.SortOrder, IsPrimary = d.IsPrimary };
    public static void Apply(this UpdateProductImageDto d, ProductImage e) { e.ProductId = d.ProductId; e.Url = d.Url; e.AltText = d.AltText; e.SortOrder = d.SortOrder; e.IsPrimary = d.IsPrimary; }
}