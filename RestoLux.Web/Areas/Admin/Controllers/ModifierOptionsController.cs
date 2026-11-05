using Microsoft.AspNetCore.Mvc;
using RestoLux.Application.Common;
using RestoLux.Application.DTOs;
using RestoLux.Application.Services;

namespace RestoLux.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class ModifierOptionsController : AdminCrudController<IModifierOptionService, ModifierOptionDto, CreateModifierOptionDto, UpdateModifierOptionDto>
{
    public ModifierOptionsController(IModifierOptionService service) : base(service) { }
}
