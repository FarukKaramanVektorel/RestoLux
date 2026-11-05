using RestoLux.Domain.Entities;

namespace RestoLux.Application.DTOs;

public record ReviewDto(
    int Id, int BranchId, int? CustomerId, string AuthorName, int Rating, string? Comment, bool IsApproved,
    bool IsFeatured, string? AdminReply, DateTime? RepliedAt, DateTime CreatedAt, DateTime UpdatedAt);

public record CreateReviewDto(
    int BranchId, int? CustomerId, string AuthorName, int Rating, string? Comment, bool IsApproved = false,
    bool IsFeatured = false);

public record UpdateReviewDto(
    int BranchId, int? CustomerId, string AuthorName, int Rating, string? Comment, bool IsApproved, bool IsFeatured,
    string? AdminReply, DateTime? RepliedAt);

public static class ReviewMappings
{
    public static ReviewDto ToDto(this Review e) => new(
        e.Id, e.BranchId, e.CustomerId, e.AuthorName, e.Rating, e.Comment, e.IsApproved, e.IsFeatured,
        e.AdminReply, e.RepliedAt, e.CreatedAt, e.UpdatedAt);

    public static Review ToEntity(this CreateReviewDto d) => new()
    {
        BranchId = d.BranchId, CustomerId = d.CustomerId, AuthorName = d.AuthorName, Rating = d.Rating,
        Comment = d.Comment, IsApproved = d.IsApproved, IsFeatured = d.IsFeatured
    };

    public static void Apply(this UpdateReviewDto d, Review e)
    {
        e.BranchId = d.BranchId; e.CustomerId = d.CustomerId; e.AuthorName = d.AuthorName; e.Rating = d.Rating;
        e.Comment = d.Comment; e.IsApproved = d.IsApproved; e.IsFeatured = d.IsFeatured;
        e.AdminReply = d.AdminReply; e.RepliedAt = d.RepliedAt;
    }
}