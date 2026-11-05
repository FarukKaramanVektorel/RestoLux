using Microsoft.AspNetCore.Mvc;
using RestoLux.Application.Common;
using RestoLux.Application.DTOs;
using RestoLux.Application.Services;

namespace RestoLux.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class BranchesController : AdminCrudController<IBranchService, BranchDto, CreateBranchDto, UpdateBranchDto>
{
    public BranchesController(IBranchService service) : base(service) { }
}
