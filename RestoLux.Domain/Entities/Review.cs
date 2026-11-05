namespace RestoLux.Domain.Entities;

public class Review : BaseEntity
{
    public int BranchId { get; set; }
    public int? CustomerId { get; set; }
    public string AuthorName { get; set; } = string.Empty;
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public bool IsApproved { get; set; }
    public bool IsFeatured { get; set; }
    public string? AdminReply { get; set; }
    public DateTime? RepliedAt { get; set; }

    // Navigation
    public Branch Branch { get; set; } = null!;
    public Customer? Customer { get; set; }
}
