namespace RestoLux.Domain.Entities;

/// <summary>
/// Represents a restaurant organization.
/// </summary>
public class Restaurant : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Slug { get; set; }
    public string? Description { get; set; }
    public string? LogoUrl { get; set; }
    public string? FaviconUrl { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Website { get; set; }
    public string? TaxId { get; set; }
    public string CurrencyCode { get; set; } = "TRY";
    public string DefaultCulture { get; set; } = "tr";
    public bool IsActive { get; set; } = true;

    // Navigation
    public ICollection<Branch> Branches { get; set; } = new List<Branch>();
    public ICollection<SiteSetting> SiteSettings { get; set; } = new List<SiteSetting>();
}
