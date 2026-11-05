using RestoLux.Domain.Entities;

namespace RestoLux.Application.DTOs;

public record CustomerDto(
    int Id, string? UserId, string FirstName, string LastName, string? Email, string? Phone, string? Notes,
    bool IsGuest, bool IsVip, int NoShowCount, int VisitCount, decimal TotalSpent, DateTime CreatedAt, DateTime UpdatedAt);

public record CreateCustomerDto(
    string? UserId, string FirstName, string LastName, string? Email, string? Phone, string? Notes,
    bool IsGuest = true, bool IsVip = false);

public record UpdateCustomerDto(
    string? UserId, string FirstName, string LastName, string? Email, string? Phone, string? Notes,
    bool IsGuest, bool IsVip, int NoShowCount, int VisitCount, decimal TotalSpent);

public static class CustomerMappings
{
    public static CustomerDto ToDto(this Customer e) => new(
        e.Id, e.UserId, e.FirstName, e.LastName, e.Email, e.Phone, e.Notes, e.IsGuest, e.IsVip, e.NoShowCount,
        e.VisitCount, e.TotalSpent, e.CreatedAt, e.UpdatedAt);

    public static Customer ToEntity(this CreateCustomerDto d) => new()
    {
        UserId = d.UserId, FirstName = d.FirstName, LastName = d.LastName, Email = d.Email, Phone = d.Phone,
        Notes = d.Notes, IsGuest = d.IsGuest, IsVip = d.IsVip
    };

    public static void Apply(this UpdateCustomerDto d, Customer e)
    {
        e.UserId = d.UserId; e.FirstName = d.FirstName; e.LastName = d.LastName; e.Email = d.Email; e.Phone = d.Phone;
        e.Notes = d.Notes; e.IsGuest = d.IsGuest; e.IsVip = d.IsVip; e.NoShowCount = d.NoShowCount;
        e.VisitCount = d.VisitCount; e.TotalSpent = d.TotalSpent;
    }
}