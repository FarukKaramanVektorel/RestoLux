namespace RestoLux.Domain.Entities;

public class MediaAsset : BaseEntity
{
    public int RestaurantId { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string OriginalFileName { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;
    public long FileSize { get; set; }
    public string? AltText { get; set; }
    public string? Title { get; set; }
    public int? Width { get; set; }
    public int? Height { get; set; }
    public string? Folder { get; set; }

    // Navigation
    public Restaurant Restaurant { get; set; } = null!;
}
