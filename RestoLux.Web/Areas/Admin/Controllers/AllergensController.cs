using Microsoft.AspNetCore.Mvc;
using RestoLux.Application.Common;
using RestoLux.Application.DTOs;
using RestoLux.Application.Services;

namespace RestoLux.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class AllergensController : AdminCrudController<IAllergenService, AllergenDto, CreateAllergenDto, UpdateAllergenDto>
{
    public AllergensController(IAllergenService service) : base(service) { }
}
