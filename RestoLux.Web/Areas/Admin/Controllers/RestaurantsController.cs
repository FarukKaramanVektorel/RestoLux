using Microsoft.AspNetCore.Mvc;
using RestoLux.Application.Common;
using RestoLux.Application.DTOs;
using RestoLux.Application.Services;

namespace RestoLux.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class RestaurantsController : AdminCrudController<IRestaurantService, RestaurantDto, CreateRestaurantDto, UpdateRestaurantDto>
{
    public RestaurantsController(IRestaurantService service) : base(service) { }
}
