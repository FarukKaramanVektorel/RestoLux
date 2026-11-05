namespace RestoLux.Domain.Entities;

/// <summary>
/// Key-value store for restaurant site settings (theme colors, fonts, social media, etc.)
/// These are injected as CSS variables in _Layout.cshtml.
/// </summary>
public class SiteSetting : BaseEntity
{
    public int RestaurantId { get; set; }
    public string Key { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public string? Group { get; set; }
    public string? Description { get; set; }
    public string? DataType { get; set; }

    // Navigation
    public Restaurant Restaurant { get; set; } = null!;
}
