namespace RestoLux.Domain.Entities;

public class ProductImage : BaseEntity
{
    public int ProductId { get; set; }
    public string Url { get; set; } = string.Empty;
    public string? AltText { get; set; }
    public int SortOrder { get; set; }
    public bool IsPrimary { get; set; }

    // Navigation
    public Product Product { get; set; } = null!;
}
