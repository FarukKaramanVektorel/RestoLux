using Microsoft.AspNetCore.Mvc;
using RestoLux.Application.Common;
using RestoLux.Application.DTOs;
using RestoLux.Application.Services;

namespace RestoLux.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class DietaryTagsController : AdminCrudController<IDietaryTagService, DietaryTagDto, CreateDietaryTagDto, UpdateDietaryTagDto>
{
    public DietaryTagsController(IDietaryTagService service) : base(service) { }
}
