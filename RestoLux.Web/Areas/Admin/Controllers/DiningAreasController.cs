using Microsoft.AspNetCore.Mvc;
using RestoLux.Application.Common;
using RestoLux.Application.DTOs;
using RestoLux.Application.Services;

namespace RestoLux.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class DiningAreasController : AdminCrudController<IDiningAreaService, DiningAreaDto, CreateDiningAreaDto, UpdateDiningAreaDto>
{
    public DiningAreasController(IDiningAreaService service) : base(service) { }
}
