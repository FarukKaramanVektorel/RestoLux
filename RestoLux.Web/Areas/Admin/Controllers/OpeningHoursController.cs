using Microsoft.AspNetCore.Mvc;
using RestoLux.Application.Common;
using RestoLux.Application.DTOs;
using RestoLux.Application.Services;

namespace RestoLux.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class OpeningHoursController : AdminCrudController<IOpeningHourService, OpeningHourDto, CreateOpeningHourDto, UpdateOpeningHourDto>
{
    public OpeningHoursController(IOpeningHourService service) : base(service) { }
}
