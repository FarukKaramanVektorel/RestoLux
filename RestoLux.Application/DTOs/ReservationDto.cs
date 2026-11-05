using RestoLux.Domain.Entities;
using RestoLux.Domain.Enums;

namespace RestoLux.Application.DTOs;

public record ReservationDto(
    int Id, int BranchId, int CustomerId, DateOnly Date, TimeOnly StartTime, TimeOnly EndTime, int GuestCount,
    ReservationStatus Status, DiningAreaType? PreferredArea, string? SpecialRequests, string? OccasionNotes,
    bool IsBirthday, string? Source, string? CancellationReason, string? ConfirmationCode,
    DateTime CreatedAt, DateTime UpdatedAt);

public record CreateReservationDto(
    int BranchId, int CustomerId, DateOnly Date, TimeOnly StartTime, TimeOnly EndTime, int GuestCount,
    DiningAreaType? PreferredArea = null, string? SpecialRequests = null, string? OccasionNotes = null,
    bool IsBirthday = false, string? Source = null);

public record UpdateReservationDto(
    int BranchId, int CustomerId, DateOnly Date, TimeOnly StartTime, TimeOnly EndTime, int GuestCount,
    ReservationStatus Status, DiningAreaType? PreferredArea, string? SpecialRequests, string? OccasionNotes,
    bool IsBirthday, string? Source, string? CancellationReason, string? ConfirmationCode);

public static class ReservationMappings
{
    public static ReservationDto ToDto(this Reservation e) => new(
        e.Id, e.BranchId, e.CustomerId, e.Date, e.StartTime, e.EndTime, e.GuestCount, e.Status, e.PreferredArea,
        e.SpecialRequests, e.OccasionNotes, e.IsBirthday, e.Source, e.CancellationReason, e.ConfirmationCode,
        e.CreatedAt, e.UpdatedAt);

    public static Reservation ToEntity(this CreateReservationDto d) => new()
    {
        BranchId = d.BranchId, CustomerId = d.CustomerId, Date = d.Date, StartTime = d.StartTime, EndTime = d.EndTime,
        GuestCount = d.GuestCount, PreferredArea = d.PreferredArea, SpecialRequests = d.SpecialRequests,
        OccasionNotes = d.OccasionNotes, IsBirthday = d.IsBirthday, Source = d.Source, Status = ReservationStatus.Pending
    };

    public static void Apply(this UpdateReservationDto d, Reservation e)
    {
        e.BranchId = d.BranchId; e.CustomerId = d.CustomerId; e.Date = d.Date; e.StartTime = d.StartTime;
        e.EndTime = d.EndTime; e.GuestCount = d.GuestCount; e.Status = d.Status; e.PreferredArea = d.PreferredArea;
        e.SpecialRequests = d.SpecialRequests; e.OccasionNotes = d.OccasionNotes; e.IsBirthday = d.IsBirthday;
        e.Source = d.Source; e.CancellationReason = d.CancellationReason; e.ConfirmationCode = d.ConfirmationCode;
    }
}