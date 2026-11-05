using Microsoft.AspNetCore.Mvc;
using RestoLux.Application.Common;
using RestoLux.Application.DTOs;
using RestoLux.Application.Services;

namespace RestoLux.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class MenusController : AdminCrudController<IMenuService, MenuDto, CreateMenuDto, UpdateMenuDto>
{
    public MenusController(IMenuService service) : base(service) { }
}
