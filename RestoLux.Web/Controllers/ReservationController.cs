using Microsoft.AspNetCore.Mvc;
using RestoLux.Application.DTOs;
using RestoLux.Application.Services;

namespace RestoLux.Web.Controllers;

public class ReservationController : Controller
{
    private readonly IBranchService _branches;
    private readonly ICustomerService _customers;
    private readonly IReservationService _reservations;

    public ReservationController(IBranchService branches, ICustomerService customers, IReservationService reservations)
    {
        _branches = branches;
        _customers = customers;
        _reservations = reservations;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.Branches = await _branches.GetAllAsync();
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(string firstName, string lastName, string? email, string? phone,
        int branchId, DateOnly date, TimeOnly startTime, TimeOnly endTime, int guestCount, string? specialRequests)
    {
        var customerResult = await _customers.CreateAsync(new CreateCustomerDto(null, firstName, lastName, email, phone, null, true));
        if (!customerResult.IsSuccess)
        {
            TempData["Error"] = customerResult.Error;
            return RedirectToAction(nameof(Index));
        }

        var reservationResult = await _reservations.CreateAsync(new CreateReservationDto(
            branchId, customerResult.Value!.Id, date, startTime, endTime, guestCount, SpecialRequests: specialRequests));

        if (!reservationResult.IsSuccess)
        {
            TempData["Error"] = reservationResult.Error;
            return RedirectToAction(nameof(Index));
        }

        return RedirectToAction(nameof(Success), new { code = reservationResult.Value!.ConfirmationCode ?? reservationResult.Value.Id.ToString() });
    }

    public IActionResult Success(string code)
    {
        ViewBag.Code = code;
        return View();
    }
}