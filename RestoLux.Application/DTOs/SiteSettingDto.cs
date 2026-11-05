using RestoLux.Domain.Entities;

namespace RestoLux.Application.DTOs;

public record SiteSettingDto(int Id, int RestaurantId, string Key, string Value, string? Group, string? Description, string? DataType, DateTime CreatedAt, DateTime UpdatedAt);
public record CreateSiteSettingDto(int RestaurantId, string Key, string Value, string? Group, string? Description, string? DataType);
public record UpdateSiteSettingDto(int RestaurantId, string Key, string Value, string? Group, string? Description, string? DataType);

public static class SiteSettingMappings
{
    public static SiteSettingDto ToDto(this SiteSetting e) => new(e.Id, e.RestaurantId, e.Key, e.Value, e.Group, e.Description, e.DataType, e.CreatedAt, e.UpdatedAt);
    public static SiteSetting ToEntity(this CreateSiteSettingDto d) => new() { RestaurantId = d.RestaurantId, Key = d.Key, Value = d.Value, Group = d.Group, Description = d.Description, DataType = d.DataType };
    public static void Apply(this UpdateSiteSettingDto d, SiteSetting e) { e.RestaurantId = d.RestaurantId; e.Key = d.Key; e.Value = d.Value; e.Group = d.Group; e.Description = d.Description; e.DataType = d.DataType; }
}