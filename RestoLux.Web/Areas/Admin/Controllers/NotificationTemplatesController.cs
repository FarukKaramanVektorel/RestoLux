using Microsoft.AspNetCore.Mvc;
using RestoLux.Application.Common;
using RestoLux.Application.DTOs;
using RestoLux.Application.Services;

namespace RestoLux.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class NotificationTemplatesController : AdminCrudController<INotificationTemplateService, NotificationTemplateDto, CreateNotificationTemplateDto, UpdateNotificationTemplateDto>
{
    public NotificationTemplatesController(INotificationTemplateService service) : base(service) { }
}
