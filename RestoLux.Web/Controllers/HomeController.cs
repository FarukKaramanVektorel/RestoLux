using Microsoft.AspNetCore.Mvc;
using RestoLux.Application.Services;

namespace RestoLux.Web.Controllers;

public class HomeController : Controller
{
    private readonly IProductService _products;
    private readonly IReviewService _reviews;
    private readonly IBranchService _branches;

    public HomeController(IProductService products, IReviewService reviews, IBranchService branches)
    {
        _products = products;
        _reviews = reviews;
        _branches = branches;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.Branches = await _branches.GetAllAsync();
        ViewBag.Products = (await _products.GetAllAsync()).Take(8).ToList();
        ViewBag.Reviews = (await _reviews.GetAllAsync()).Where(r => r.IsApproved).Take(6).ToList();
        return View();
    }

    public IActionResult Privacy() => View();
}