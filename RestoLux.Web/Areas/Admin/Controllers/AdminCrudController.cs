using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestoLux.Application.Common;
using RestoLux.Web.Models.Admin;

namespace RestoLux.Web.Areas.Admin.Controllers;

[Authorize(Roles = "Admin")]
public abstract class AdminCrudController<TService, TDto, TCreate, TUpdate> : Controller
    where TService : ICrudService<TDto, TCreate, TUpdate>
{
    protected readonly TService Service;
    protected AdminCrudController(TService service) => Service = service;

    private static readonly Dictionary<string, string> TurkishTitles = new()
    {
        ["Allergen"] = "Alerjenler",
        ["Branch"] = "Şubeler",
        ["BranchProductAvailability"] = "Şube Ürün Uygunluğu",
        ["ContentPage"] = "İçerik Sayfaları",
        ["Customer"] = "Müşteriler",
        ["DietaryTag"] = "Diyet Etiketleri",
        ["DiningArea"] = "Yemek Alanları",
        ["DiningTable"] = "Masalar",
        ["Menu"] = "Menüler",
        ["MenuCategory"] = "Menü Kategorileri",
        ["ModifierGroup"] = "Modifier Grupları",
        ["ModifierOption"] = "Modifier Seçenekleri",
        ["NotificationTemplate"] = "Bildirim Şablonları",
        ["OpeningHour"] = "Açılış Saatleri",
        ["Product"] = "Ürünler",
        ["ProductImage"] = "Ürün Görselleri",
        ["ProductVariant"] = "Ürün Varyantları",
        ["Reservation"] = "Rezervasyonlar",
        ["Restaurant"] = "Restoranlar",
        ["Review"] = "Yorumlar",
        ["SiteSetting"] = "Site Ayarları",
        ["SpecialClosure"] = "Özel Kapanışlar",
        ["TaxRule"] = "Vergi Kuralları"
    };

    protected virtual string Title
    {
        get
        {
            var name = typeof(TDto).Name.Replace("Dto", "");
            return TurkishTitles.TryGetValue(name, out var tr) ? tr : name;
        }
    }

    public virtual async Task<IActionResult> Index()
    {
        var items = await Service.GetAllAsync();
        var vm = new AdminListViewModel { Title = Title + " Listesi", Items = items.Cast<object>().ToList() };
        return View("~/Areas/Admin/Views/Shared/GenericIndex.cshtml", vm);
    }

    public virtual async Task<IActionResult> Details(int id)
    {
        var item = await Service.GetByIdAsync(id);
        if (item is null) return NotFound();
        return View("~/Areas/Admin/Views/Shared/GenericDetails.cshtml", item);
    }

    public virtual IActionResult Create()
    {
        ViewData["ModelType"] = typeof(TCreate).AssemblyQualifiedName;
        return View("~/Areas/Admin/Views/Shared/GenericCreate.cshtml", null);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public virtual async Task<IActionResult> Create(TCreate model)
    {
        if (!ModelState.IsValid)
            return View("~/Areas/Admin/Views/Shared/GenericCreate.cshtml", model);

        var validator = HttpContext.RequestServices.GetService<IValidator<TCreate>>();
        if (validator is not null)
        {
            var vr = await validator.ValidateAsync(model);
            if (!vr.IsValid)
            {
                foreach (var e in vr.Errors) ModelState.AddModelError(e.PropertyName, e.ErrorMessage);
                return View("~/Areas/Admin/Views/Shared/GenericCreate.cshtml", model);
            }
        }

        var res = await Service.CreateAsync(model);
        if (!res.IsSuccess)
        {
            ModelState.AddModelError(string.Empty, res.Error ?? "Hata oluştu.");
            return View("~/Areas/Admin/Views/Shared/GenericCreate.cshtml", model);
        }
        return RedirectToAction(nameof(Index));
    }

    public virtual async Task<IActionResult> Edit(int id)
    {
        var item = await Service.GetByIdAsync(id);
        if (item is null) return NotFound();
        var update = CreateInstanceFrom<TUpdate>(item);
        ViewData["Id"] = id;
        return View("~/Areas/Admin/Views/Shared/GenericEdit.cshtml", update);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public virtual async Task<IActionResult> Edit(int id, TUpdate model)
    {
        if (!ModelState.IsValid)
        {
            ViewData["Id"] = id;
            return View("~/Areas/Admin/Views/Shared/GenericEdit.cshtml", model);
        }
        var validator = HttpContext.RequestServices.GetService<IValidator<TUpdate>>();
        if (validator is not null)
        {
            var vr = await validator.ValidateAsync(model);
            if (!vr.IsValid)
            {
                foreach (var e in vr.Errors) ModelState.AddModelError(e.PropertyName, e.ErrorMessage);
                ViewData["Id"] = id;
                return View("~/Areas/Admin/Views/Shared/GenericEdit.cshtml", model);
            }
        }
        var res = await Service.UpdateAsync(id, model);
        if (!res.IsSuccess)
        {
            ModelState.AddModelError(string.Empty, res.Error ?? "Hata oluştu.");
            ViewData["Id"] = id;
            return View("~/Areas/Admin/Views/Shared/GenericEdit.cshtml", model);
        }
        return RedirectToAction(nameof(Index));
    }

    public virtual async Task<IActionResult> Delete(int id)
    {
        var item = await Service.GetByIdAsync(id);
        if (item is null) return NotFound();
        return View("~/Areas/Admin/Views/Shared/GenericDelete.cshtml", item);
    }

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public virtual async Task<IActionResult> DeleteConfirmed(int id)
    {
        await Service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }

    private static T CreateInstance<T>()
    {
        var type = typeof(T);
        var ctor = type.GetConstructors().OrderByDescending(c => c.GetParameters().Length).FirstOrDefault();
        if (ctor is null)
            return default!;
        var args = ctor.GetParameters().Select(p =>
            p.ParameterType.IsValueType ? Activator.CreateInstance(p.ParameterType) : null).ToArray();
        return (T)ctor.Invoke(args);
    }

    protected static T CreateInstanceFrom<T>(object source)
    {
        var type = typeof(T);
        var ctor = type.GetConstructors().OrderByDescending(c => c.GetParameters().Length).FirstOrDefault();
        if (ctor is null)
            return default!;
        var srcProps = source.GetType().GetProperties();
        var args = ctor.GetParameters().Select(p =>
        {
            var prop = Array.Find(srcProps, x => string.Equals(x.Name, p.Name, StringComparison.OrdinalIgnoreCase));
            var val = prop?.GetValue(source);
            if (val is not null && !p.ParameterType.IsAssignableFrom(val.GetType()))
            {
                try { val = Convert.ChangeType(val, Nullable.GetUnderlyingType(p.ParameterType) ?? p.ParameterType); }
                catch { val = null; }
            }
            if (val is null && p.ParameterType.IsValueType)
                val = Activator.CreateInstance(p.ParameterType);
            return val;
        }).ToArray();
        return (T)ctor.Invoke(args);
    }

    private static void CopyMatching(object source, object target)
    {
        var sp = source.GetType().GetProperties();
        var tp = target.GetType().GetProperties();
        foreach (var p in sp)
        {
            var t = Array.Find(tp, x => x.Name == p.Name && x.CanWrite);
            if (t is not null && t.PropertyType.IsAssignableFrom(p.PropertyType))
                t.SetValue(target, p.GetValue(source));
        }
    }
}