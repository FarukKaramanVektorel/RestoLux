using RestoLux.Domain.Entities;

namespace RestoLux.Application.DTOs;

public record RestaurantDto(
    int Id,
    string Name,
    string? Slug,
    string? Description,
    string? LogoUrl,
    string? FaviconUrl,
    string? Email,
    string? Phone,
    string? Website,
    string? TaxId,
    string CurrencyCode,
    string DefaultCulture,
    bool IsActive,
    DateTime CreatedAt,
    DateTime UpdatedAt);

public record CreateRestaurantDto(
    string Name,
    string? Slug = null,
    string? Description = null,
    string? LogoUrl = null,
    string? FaviconUrl = null,
    string? Email = null,
    string? Phone = null,
    string? Website = null,
    string? TaxId = null,
    string CurrencyCode = "TRY",
    string DefaultCulture = "tr",
    bool IsActive = true);

public record UpdateRestaurantDto(
    string Name,
    string? Slug,
    string? Description,
    string? LogoUrl,
    string? FaviconUrl,
    string? Email,
    string? Phone,
    string? Website,
    string? TaxId,
    string CurrencyCode,
    string DefaultCulture,
    bool IsActive);

public static class RestaurantMappings
{
    public static RestaurantDto ToDto(this Restaurant e) => new(
        e.Id, e.Name, e.Slug, e.Description, e.LogoUrl, e.FaviconUrl, e.Email, e.Phone, e.Website, e.TaxId,
        e.CurrencyCode, e.DefaultCulture, e.IsActive, e.CreatedAt, e.UpdatedAt);

    public static Restaurant ToEntity(this CreateRestaurantDto d) => new()
    {
        Name = d.Name, Slug = d.Slug, Description = d.Description, LogoUrl = d.LogoUrl, FaviconUrl = d.FaviconUrl,
        Email = d.Email, Phone = d.Phone, Website = d.Website, TaxId = d.TaxId, CurrencyCode = d.CurrencyCode,
        DefaultCulture = d.DefaultCulture, IsActive = d.IsActive
    };

    public static void Apply(this UpdateRestaurantDto d, Restaurant e)
    {
        e.Name = d.Name; e.Slug = d.Slug; e.Description = d.Description; e.LogoUrl = d.LogoUrl;
        e.FaviconUrl = d.FaviconUrl; e.Email = d.Email; e.Phone = d.Phone; e.Website = d.Website;
        e.TaxId = d.TaxId; e.CurrencyCode = d.CurrencyCode; e.DefaultCulture = d.DefaultCulture; e.IsActive = d.IsActive;
    }
}