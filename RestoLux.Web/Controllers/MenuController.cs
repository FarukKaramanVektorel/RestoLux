using Microsoft.AspNetCore.Mvc;
using RestoLux.Application.Services;

namespace RestoLux.Web.Controllers;

public class MenuController : Controller
{
    private readonly IBranchService _branches;
    private readonly IMenuService _menus;
    private readonly IMenuCategoryService _categories;
    private readonly IProductService _products;
    private readonly IProductImageService _images;

    public MenuController(IBranchService branches, IMenuService menus, IMenuCategoryService categories, IProductService products, IProductImageService images)
    {
        _branches = branches;
        _menus = menus;
        _categories = categories;
        _products = products;
        _images = images;
    }

    public async Task<IActionResult> Index(int? branchId)
    {
        var branches = await _branches.GetAllAsync();
        ViewBag.Branches = branches;
        var selected = branchId ?? branches.FirstOrDefault()?.Id;
        ViewBag.SelectedBranchId = selected;

        var menus = (await _menus.GetAllAsync()).Where(m => m.BranchId == selected && m.IsActive).ToList();
        ViewBag.Menus = menus;

        var menuIds = menus.Select(m => m.Id).ToHashSet();
        var categories = (await _categories.GetAllAsync()).Where(c => menuIds.Contains(c.MenuId) && c.IsActive).ToList();
        ViewBag.Categories = categories;

        var catIds = categories.Select(c => c.Id).ToHashSet();
        var products = (await _products.GetAllAsync()).Where(p => catIds.Contains(p.CategoryId) && p.IsActive).ToList();
        ViewBag.Products = products;
        ViewBag.ProductImages = await _images.GetAllAsync();

        return View();
    }
}