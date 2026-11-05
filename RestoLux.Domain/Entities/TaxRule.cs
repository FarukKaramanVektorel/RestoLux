namespace RestoLux.Domain.Entities;

/// <summary>
/// Tax rules by product category (e.g., food 10%, beverage 20%).
/// Prices are stored VAT-inclusive.
/// </summary>
public class TaxRule : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public decimal TaxPercentage { get; set; }
    public bool IsDefault { get; set; }
    public bool IsActive { get; set; } = true;
}
