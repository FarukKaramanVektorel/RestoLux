namespace RestoLux.Domain.Entities;

/// <summary>
/// Base entity with common audit fields for all domain entities.
/// </summary>
public abstract class BaseEntity
{
    /// <summary>Primary key.</summary>
    public int Id { get; set; }

    /// <summary>Record creation timestamp (UTC).</summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>Last update timestamp (UTC).</summary>
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>Soft delete flag.</summary>
    public bool IsDeleted { get; set; }
}
