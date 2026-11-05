using RestoLux.Domain.Entities;

namespace RestoLux.Application.DTOs;

public record BranchProductAvailabilityDto(int Id, int BranchId, int ProductId, bool IsAvailable, decimal? OverridePrice, DateTime CreatedAt, DateTime UpdatedAt);
public record CreateBranchProductAvailabilityDto(int BranchId, int ProductId, bool IsAvailable = true, decimal? OverridePrice = null);
public record UpdateBranchProductAvailabilityDto(int BranchId, int ProductId, bool IsAvailable, decimal? OverridePrice);

public static class BranchProductAvailabilityMappings
{
    public static BranchProductAvailabilityDto ToDto(this BranchProductAvailability e) => new(e.Id, e.BranchId, e.ProductId, e.IsAvailable, e.OverridePrice, e.CreatedAt, e.UpdatedAt);
    public static BranchProductAvailability ToEntity(this CreateBranchProductAvailabilityDto d) => new() { BranchId = d.BranchId, ProductId = d.ProductId, IsAvailable = d.IsAvailable, OverridePrice = d.OverridePrice };
    public static void Apply(this UpdateBranchProductAvailabilityDto d, BranchProductAvailability e) { e.BranchId = d.BranchId; e.ProductId = d.ProductId; e.IsAvailable = d.IsAvailable; e.OverridePrice = d.OverridePrice; }
}