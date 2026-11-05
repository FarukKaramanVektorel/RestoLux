using Microsoft.AspNetCore.Mvc;
using RestoLux.Application.Common;
using RestoLux.Application.DTOs;
using RestoLux.Application.Services;

namespace RestoLux.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class ModifierGroupsController : AdminCrudController<IModifierGroupService, ModifierGroupDto, CreateModifierGroupDto, UpdateModifierGroupDto>
{
    public ModifierGroupsController(IModifierGroupService service) : base(service) { }
}
