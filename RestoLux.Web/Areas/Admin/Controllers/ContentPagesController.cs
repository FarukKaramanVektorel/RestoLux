using Microsoft.AspNetCore.Mvc;
using RestoLux.Application.Common;
using RestoLux.Application.DTOs;
using RestoLux.Application.Services;

namespace RestoLux.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class ContentPagesController : AdminCrudController<IContentPageService, ContentPageDto, CreateContentPageDto, UpdateContentPageDto>
{
    public ContentPagesController(IContentPageService service) : base(service) { }
}
