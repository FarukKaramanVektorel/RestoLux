using Microsoft.AspNetCore.Mvc;
using RestoLux.Application.Common;
using RestoLux.Application.DTOs;
using RestoLux.Application.Services;

namespace RestoLux.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class ReviewsController : AdminCrudController<IReviewService, ReviewDto, CreateReviewDto, UpdateReviewDto>
{
    public ReviewsController(IReviewService service) : base(service) { }
}
