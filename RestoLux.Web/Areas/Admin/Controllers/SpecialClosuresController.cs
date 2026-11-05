using Microsoft.AspNetCore.Mvc;
using RestoLux.Application.Common;
using RestoLux.Application.DTOs;
using RestoLux.Application.Services;

namespace RestoLux.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class SpecialClosuresController : AdminCrudController<ISpecialClosureService, SpecialClosureDto, CreateSpecialClosureDto, UpdateSpecialClosureDto>
{
    public SpecialClosuresController(ISpecialClosureService service) : base(service) { }
}
