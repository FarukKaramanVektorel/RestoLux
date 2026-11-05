using Microsoft.AspNetCore.Mvc;
using RestoLux.Application.DTOs;
using RestoLux.Application.Services;
using RestoLux.Domain.Enums;

namespace RestoLux.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class ReservationsController : AdminCrudController<IReservationService, ReservationDto, CreateReservationDto, UpdateReservationDto>
{
    private readonly ICustomerService _customers;
    private readonly IBranchService _branches;

    public ReservationsController(IReservationService service, ICustomerService customers, IBranchService branches)
        : base(service)
    {
        _customers = customers;
        _branches = branches;
    }

    public override async Task<IActionResult> Index()
    {
        var reservations = await Service.GetAllAsync();
        var customers = await _customers.GetAllAsync();
        var branches = await _branches.GetAllAsync();

        var customerMap = customers.ToDictionary(c => c.Id, c => $"{c.FirstName} {c.LastName}");
        var branchMap = branches.ToDictionary(b => b.Id, b => b.Name);

        var rows = reservations.Select(r => new ReservationRowDto(
            r.Id,
            customerMap.TryGetValue(r.CustomerId, out var cn) ? cn : $"#{r.CustomerId}",
            branchMap.TryGetValue(r.BranchId, out var bn) ? bn : $"#{r.BranchId}",
            r.Date,
            r.StartTime,
            r.EndTime,
            r.GuestCount,
            r.Status,
            r.SpecialRequests
        )).ToList();

        ViewBag.Rows = rows;
        return View("~/Areas/Admin/Views/Reservations/Index.cshtml");
    }

    public override async Task<IActionResult> Details(int id) => await base.Details(id);

    public override IActionResult Create()
    {
        ViewData["ModelType"] = typeof(CreateReservationDto).AssemblyQualifiedName;
        return base.Create();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateWithImage(CreateReservationDto model) // not used
    {
        return await base.Create(model) as IActionResult ?? RedirectToAction(nameof(Index));
    }

    public override async Task<IActionResult> Edit(int id) => await base.Edit(id);

    public override async Task<IActionResult> Delete(int id) => await base.Delete(id);

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public override async Task<IActionResult> DeleteConfirmed(int id) => await base.DeleteConfirmed(id);
}

public record ReservationRowDto(
    int Id,
    string CustomerName,
    string BranchName,
    DateOnly Date,
    TimeOnly StartTime,
    TimeOnly EndTime,
    int GuestCount,
    ReservationStatus Status,
    string? SpecialRequests);