using Microsoft.AspNetCore.Mvc;
using RestoLux.Application.DTOs;
using RestoLux.Application.Services;
using RestoLux.Domain.Interfaces;

namespace RestoLux.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductsController : AdminCrudController<IProductService, ProductDto, CreateProductDto, UpdateProductDto>
{
    private readonly IFileStorageService _storage;
    private readonly IProductImageService _images;
    private readonly IMenuCategoryService _categories;

    public ProductsController(IProductService service, IFileStorageService storage, IProductImageService images, IMenuCategoryService categories)
        : base(service)
    {
        _storage = storage;
        _images = images;
        _categories = categories;
    }

    public override async Task<IActionResult> Index()
    {
        var products = await Service.GetAllAsync();
        var images = await _images.GetAllAsync();
        var cats = await _categories.GetAllAsync();
        ViewBag.Products = products;
        ViewBag.ProductImages = images;
        ViewBag.Categories = cats;
        return View("~/Areas/Admin/Views/Products/Index.cshtml");
    }

    public override IActionResult Create()
    {
        ViewData["ModelType"] = typeof(CreateProductDto).AssemblyQualifiedName;
        ViewBag.Categories = _categories.GetAllAsync().GetAwaiter().GetResult();
        return View("~/Areas/Admin/Views/Products/Create.cshtml", null);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateWithImage(CreateProductDto model, IFormFile? imageFile)
    {
        if (!ModelState.IsValid)
        {
            ViewData["ModelType"] = typeof(CreateProductDto).AssemblyQualifiedName;
            ViewBag.Categories = await _categories.GetAllAsync();
            return View("~/Areas/Admin/Views/Products/Create.cshtml", model);
        }

        var result = await Service.CreateAsync(model);
        if (!result.IsSuccess)
        {
            ModelState.AddModelError(string.Empty, result.Error ?? "Hata");
            ViewData["ModelType"] = typeof(CreateProductDto).AssemblyQualifiedName;
            ViewBag.Categories = await _categories.GetAllAsync();
            return View("~/Areas/Admin/Views/Products/Create.cshtml", model);
        }

        if (imageFile != null && imageFile.Length > 0)
        {
            await using var stream = imageFile.OpenReadStream();
            var relativePath = await _storage.UploadFileAsync(stream, imageFile.FileName, imageFile.ContentType, "products");
            var url = _storage.GetFileUrl(relativePath);
            await _images.CreateAsync(new CreateProductImageDto(result.Value!.Id, url, model.Name, 0, true));
        }

        return RedirectToAction(nameof(Index));
    }

    public override async Task<IActionResult> Edit(int id)
    {
        var item = await Service.GetByIdAsync(id);
        if (item is null) return NotFound();
        var update = CreateInstanceFrom<UpdateProductDto>(item);
        var imgs = await _images.GetAllAsync();
        ViewBag.ProductImages = imgs.Where(i => i.ProductId == id).ToList();
        ViewBag.Categories = await _categories.GetAllAsync();
        ViewBag.EditId = id;
        ViewData["Id"] = id;
        return View("~/Areas/Admin/Views/Products/Edit.cshtml", update);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> EditWithImage(int id, UpdateProductDto model, IFormFile? imageFile)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.EditId = id;
            ViewData["Id"] = id;
            ViewBag.Categories = await _categories.GetAllAsync();
            return View("~/Areas/Admin/Views/Products/Edit.cshtml", model);
        }

        var result = await Service.UpdateAsync(id, model);
        if (!result.IsSuccess)
        {
            ModelState.AddModelError(string.Empty, result.Error ?? "Hata");
            ViewBag.EditId = id;
            ViewData["Id"] = id;
            ViewBag.Categories = await _categories.GetAllAsync();
            return View("~/Areas/Admin/Views/Products/Edit.cshtml", model);
        }

        if (imageFile != null && imageFile.Length > 0)
        {
            await using var stream = imageFile.OpenReadStream();
            var relativePath = await _storage.UploadFileAsync(stream, imageFile.FileName, imageFile.ContentType, "products");
            var url = _storage.GetFileUrl(relativePath);
            await _images.CreateAsync(new CreateProductImageDto(id, url, model.Name, 0, true));
        }

        return RedirectToAction(nameof(Index));
    }

    public override async Task<IActionResult> Delete(int id) => await base.Delete(id);

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public override async Task<IActionResult> DeleteConfirmed(int id) => await base.DeleteConfirmed(id);
}