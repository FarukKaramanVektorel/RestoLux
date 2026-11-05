namespace RestoLux.Domain.Entities;

/// <summary>
/// Represents a restaurant branch/location.
/// </summary>
public class Branch : BaseEntity
{
    public int RestaurantId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Slug { get; set; }
    public string? Description { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? District { get; set; }
    public string? PostalCode { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? GoogleMapsUrl { get; set; }
    public int Capacity { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsMainBranch { get; set; }

    // Navigation
    public Restaurant Restaurant { get; set; } = null!;
    public ICollection<OpeningHour> OpeningHours { get; set; } = new List<OpeningHour>();
    public ICollection<SpecialClosure> SpecialClosures { get; set; } = new List<SpecialClosure>();
    public ICollection<DiningArea> DiningAreas { get; set; } = new List<DiningArea>();
    public ICollection<UserBranch> UserBranches { get; set; } = new List<UserBranch>();
}
