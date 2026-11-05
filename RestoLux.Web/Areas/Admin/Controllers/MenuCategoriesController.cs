using Microsoft.AspNetCore.Mvc;
using RestoLux.Application.Common;
using RestoLux.Application.DTOs;
using RestoLux.Application.Services;

namespace RestoLux.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class MenuCategoriesController : AdminCrudController<IMenuCategoryService, MenuCategoryDto, CreateMenuCategoryDto, UpdateMenuCategoryDto>
{
    public MenuCategoriesController(IMenuCategoryService service) : base(service) { }
}
