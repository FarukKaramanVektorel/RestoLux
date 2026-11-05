using Microsoft.AspNetCore.Mvc;
using RestoLux.Application.Common;
using RestoLux.Application.DTOs;
using RestoLux.Application.Services;

namespace RestoLux.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductVariantsController : AdminCrudController<IProductVariantService, ProductVariantDto, CreateProductVariantDto, UpdateProductVariantDto>
{
    public ProductVariantsController(IProductVariantService service) : base(service) { }
}
