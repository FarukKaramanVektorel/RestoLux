namespace RestoLux.Domain.Entities;

/// <summary>
/// Stores localized text for any entity field.
/// Uses Entity + EntityId + Culture + Field as composite key.
/// </summary>
public class LocalizedText : BaseEntity
{
    public string EntityName { get; set; } = string.Empty;
    public int EntityId { get; set; }
    public string Culture { get; set; } = string.Empty;
    public string FieldName { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
}
