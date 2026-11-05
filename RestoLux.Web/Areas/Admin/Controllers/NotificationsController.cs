using Microsoft.AspNetCore.Mvc;
using RestoLux.Application.Services;
using RestoLux.Domain.Enums;

namespace RestoLux.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class NotificationsController : Controller
{
    private readonly IReservationService _reservations;

    public NotificationsController(IReservationService reservations)
    {
        _reservations = reservations;
    }

    [HttpGet]
    public async Task<IActionResult> UnreadCount()
    {
        var reservations = await _reservations.GetAllAsync();
        var count = reservations.Count(r => r.Status == ReservationStatus.Pending);
        return Json(new { count });
    }
}