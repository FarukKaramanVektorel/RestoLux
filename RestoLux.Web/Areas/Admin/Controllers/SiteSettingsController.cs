using Microsoft.AspNetCore.Mvc;
using RestoLux.Application.Common;
using RestoLux.Application.DTOs;
using RestoLux.Application.Services;

namespace RestoLux.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class SiteSettingsController : AdminCrudController<ISiteSettingService, SiteSettingDto, CreateSiteSettingDto, UpdateSiteSettingDto>
{
    public SiteSettingsController(ISiteSettingService service) : base(service) { }
}
