using RestoLux.Domain.Enums;

namespace RestoLux.Domain.Entities;

public class ContentPage : BaseEntity
{
    public int RestaurantId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string? Content { get; set; }
    public string? MetaTitle { get; set; }
    public string? MetaDescription { get; set; }
    public string? FeaturedImageUrl { get; set; }
    public ContentPageStatus Status { get; set; } = ContentPageStatus.Draft;
    public int SortOrder { get; set; }
    public string? PageType { get; set; }
    public DateTime? PublishedAt { get; set; }

    // Navigation
    public Restaurant Restaurant { get; set; } = null!;
}
