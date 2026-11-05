using Microsoft.AspNetCore.Mvc;
using RestoLux.Application.Common;
using RestoLux.Application.DTOs;
using RestoLux.Application.Services;

namespace RestoLux.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class CustomersController : AdminCrudController<ICustomerService, CustomerDto, CreateCustomerDto, UpdateCustomerDto>
{
    public CustomersController(ICustomerService service) : base(service) { }
}
