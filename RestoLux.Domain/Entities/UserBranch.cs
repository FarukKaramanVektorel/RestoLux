namespace RestoLux.Domain.Entities;

/// <summary>
/// Maps users to the branches they have access to.
/// </summary>
public class UserBranch : BaseEntity
{
    public string UserId { get; set; } = string.Empty;
    public int BranchId { get; set; }
    public bool IsPrimary { get; set; }

    // Navigation
    public Branch Branch { get; set; } = null!;
}
