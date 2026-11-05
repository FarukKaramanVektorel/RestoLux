using RestoLux.Domain.Entities;

namespace RestoLux.Application.DTOs;

public record AllergenDto(int Id, string Name, string? Icon, int SortOrder, DateTime CreatedAt, DateTime UpdatedAt);
public record CreateAllergenDto(string Name, string? Icon, int SortOrder = 0);
public record UpdateAllergenDto(string Name, string? Icon, int SortOrder);

public static class AllergenMappings
{
    public static AllergenDto ToDto(this Allergen e) => new(e.Id, e.Name, e.Icon, e.SortOrder, e.CreatedAt, e.UpdatedAt);
    public static Allergen ToEntity(this CreateAllergenDto d) => new() { Name = d.Name, Icon = d.Icon, SortOrder = d.SortOrder };
    public static void Apply(this UpdateAllergenDto d, Allergen e) { e.Name = d.Name; e.Icon = d.Icon; e.SortOrder = d.SortOrder; }
}