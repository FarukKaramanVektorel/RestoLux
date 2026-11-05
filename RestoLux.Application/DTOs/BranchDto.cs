using RestoLux.Domain.Entities;

namespace RestoLux.Application.DTOs;

public record BranchDto(
    int Id, int RestaurantId, string Name, string? Slug, string? Description, string? Address, string? City,
    string? District, string? PostalCode, double? Latitude, double? Longitude, string? Phone, string? Email,
    string? GoogleMapsUrl, int Capacity, bool IsActive, bool IsMainBranch, DateTime CreatedAt, DateTime UpdatedAt);

public record CreateBranchDto(
    int RestaurantId, string Name, string? Slug, string? Description, string? Address, string? City,
    string? District, string? PostalCode, double? Latitude, double? Longitude, string? Phone, string? Email,
    string? GoogleMapsUrl, int Capacity, bool IsActive = true, bool IsMainBranch = false);

public record UpdateBranchDto(
    int RestaurantId, string Name, string? Slug, string? Description, string? Address, string? City,
    string? District, string? PostalCode, double? Latitude, double? Longitude, string? Phone, string? Email,
    string? GoogleMapsUrl, int Capacity, bool IsActive, bool IsMainBranch);

public static class BranchMappings
{
    public static BranchDto ToDto(this Branch e) => new(
        e.Id, e.RestaurantId, e.Name, e.Slug, e.Description, e.Address, e.City, e.District, e.PostalCode,
        e.Latitude, e.Longitude, e.Phone, e.Email, e.GoogleMapsUrl, e.Capacity, e.IsActive, e.IsMainBranch,
        e.CreatedAt, e.UpdatedAt);

    public static Branch ToEntity(this CreateBranchDto d) => new()
    {
        RestaurantId = d.RestaurantId, Name = d.Name, Slug = d.Slug, Description = d.Description, Address = d.Address,
        City = d.City, District = d.District, PostalCode = d.PostalCode, Latitude = d.Latitude, Longitude = d.Longitude,
        Phone = d.Phone, Email = d.Email, GoogleMapsUrl = d.GoogleMapsUrl, Capacity = d.Capacity, IsActive = d.IsActive,
        IsMainBranch = d.IsMainBranch
    };

    public static void Apply(this UpdateBranchDto d, Branch e)
    {
        e.RestaurantId = d.RestaurantId; e.Name = d.Name; e.Slug = d.Slug; e.Description = d.Description;
        e.Address = d.Address; e.City = d.City; e.District = d.District; e.PostalCode = d.PostalCode;
        e.Latitude = d.Latitude; e.Longitude = d.Longitude; e.Phone = d.Phone; e.Email = d.Email;
        e.GoogleMapsUrl = d.GoogleMapsUrl; e.Capacity = d.Capacity; e.IsActive = d.IsActive; e.IsMainBranch = d.IsMainBranch;
    }
}