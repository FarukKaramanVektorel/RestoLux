using RestoLux.Domain.Entities;
using RestoLux.Domain.Enums;

namespace RestoLux.Application.DTOs;

public record ContentPageDto(int Id, int RestaurantId, string Title, string Slug, string? Content, string? MetaTitle, string? MetaDescription, string? FeaturedImageUrl, ContentPageStatus Status, int SortOrder, string? PageType, DateTime? PublishedAt, DateTime CreatedAt, DateTime UpdatedAt);
public record CreateContentPageDto(int RestaurantId, string Title, string Slug, string? Content, string? MetaTitle, string? MetaDescription, string? FeaturedImageUrl, ContentPageStatus Status = ContentPageStatus.Draft, int SortOrder = 0, string? PageType = null, DateTime? PublishedAt = null);
public record UpdateContentPageDto(int RestaurantId, string Title, string Slug, string? Content, string? MetaTitle, string? MetaDescription, string? FeaturedImageUrl, ContentPageStatus Status, int SortOrder, string? PageType, DateTime? PublishedAt);

public static class ContentPageMappings
{
    public static ContentPageDto ToDto(this ContentPage e) => new(e.Id, e.RestaurantId, e.Title, e.Slug, e.Content, e.MetaTitle, e.MetaDescription, e.FeaturedImageUrl, e.Status, e.SortOrder, e.PageType, e.PublishedAt, e.CreatedAt, e.UpdatedAt);
    public static ContentPage ToEntity(this CreateContentPageDto d) => new() { RestaurantId = d.RestaurantId, Title = d.Title, Slug = d.Slug, Content = d.Content, MetaTitle = d.MetaTitle, MetaDescription = d.MetaDescription, FeaturedImageUrl = d.FeaturedImageUrl, Status = d.Status, SortOrder = d.SortOrder, PageType = d.PageType, PublishedAt = d.PublishedAt };
    public static void Apply(this UpdateContentPageDto d, ContentPage e) { e.RestaurantId = d.RestaurantId; e.Title = d.Title; e.Slug = d.Slug; e.Content = d.Content; e.MetaTitle = d.MetaTitle; e.MetaDescription = d.MetaDescription; e.FeaturedImageUrl = d.FeaturedImageUrl; e.Status = d.Status; e.SortOrder = d.SortOrder; e.PageType = d.PageType; e.PublishedAt = d.PublishedAt; }
}