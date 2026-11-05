using RestoLux.Domain.Entities;

namespace RestoLux.Application.DTOs;

public record TaxRuleDto(int Id, string Name, decimal TaxPercentage, bool IsDefault, bool IsActive, DateTime CreatedAt, DateTime UpdatedAt);
public record CreateTaxRuleDto(string Name, decimal TaxPercentage, bool IsDefault = false, bool IsActive = true);
public record UpdateTaxRuleDto(string Name, decimal TaxPercentage, bool IsDefault, bool IsActive);

public static class TaxRuleMappings
{
    public static TaxRuleDto ToDto(this TaxRule e) => new(e.Id, e.Name, e.TaxPercentage, e.IsDefault, e.IsActive, e.CreatedAt, e.UpdatedAt);
    public static TaxRule ToEntity(this CreateTaxRuleDto d) => new() { Name = d.Name, TaxPercentage = d.TaxPercentage, IsDefault = d.IsDefault, IsActive = d.IsActive };
    public static void Apply(this UpdateTaxRuleDto d, TaxRule e) { e.Name = d.Name; e.TaxPercentage = d.TaxPercentage; e.IsDefault = d.IsDefault; e.IsActive = d.IsActive; }
}