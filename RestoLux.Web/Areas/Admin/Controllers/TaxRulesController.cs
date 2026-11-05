using Microsoft.AspNetCore.Mvc;
using RestoLux.Application.Common;
using RestoLux.Application.DTOs;
using RestoLux.Application.Services;

namespace RestoLux.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class TaxRulesController : AdminCrudController<ITaxRuleService, TaxRuleDto, CreateTaxRuleDto, UpdateTaxRuleDto>
{
    public TaxRulesController(ITaxRuleService service) : base(service) { }
}
