using Microsoft.AspNetCore.Mvc;
using RestoLux.Application.Common;
using RestoLux.Application.DTOs;
using RestoLux.Application.Services;

namespace RestoLux.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class BranchProductAvailabilitiesController : AdminCrudController<IBranchProductAvailabilityService, BranchProductAvailabilityDto, CreateBranchProductAvailabilityDto, UpdateBranchProductAvailabilityDto>
{
    public BranchProductAvailabilitiesController(IBranchProductAvailabilityService service) : base(service) { }
}
