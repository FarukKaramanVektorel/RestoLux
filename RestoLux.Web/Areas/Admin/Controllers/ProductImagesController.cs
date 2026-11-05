using Microsoft.AspNetCore.Mvc;
using RestoLux.Application.DTOs;
using RestoLux.Application.Services;
using RestoLux.Domain.Interfaces;

namespace RestoLux.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductImagesController : AdminCrudController<IProductImageService, ProductImageDto, CreateProductImageDto, UpdateProductImageDto>
{
    private readonly IFileStorageService _storage;
    private readonly IProductService _products;

    public ProductImagesController(IProductImageService service, IFileStorageService storage, IProductService products)
        : base(service)
    {
        _storage = storage;
        _products = products;
    }

    public override IActionResult Create()
    {
        ViewBag.Products = _products.GetAllAsync().GetAwaiter().GetResult();
        return View("~/Areas/Admin/Views/ProductImages/Create.cshtml");
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Upload(int productId, IFormFile file, string? altText, int sortOrder, bool isPrimary)
    {
        if (file == null || file.Length == 0)
        {
            ModelState.AddModelError("file", "Dosya seçiniz.");
            ViewBag.Products = await _products.GetAllAsync();
            return View("~/Areas/Admin/Views/ProductImages/Create.cshtml");
        }

        await using var stream = file.OpenReadStream();
        var relativePath = await _storage.UploadFileAsync(stream, file.FileName, file.ContentType, "products");
        var url = _storage.GetFileUrl(relativePath);

        var result = await Service.CreateAsync(new CreateProductImageDto(productId, url, altText, sortOrder, isPrimary));
        if (!result.IsSuccess)
        {
            ModelState.AddModelError(string.Empty, result.Error ?? "Hata");
            ViewBag.Products = await _products.GetAllAsync();
            return View("~/Areas/Admin/Views/ProductImages/Create.cshtml");
        }

        return RedirectToAction(nameof(Index));
    }
}