using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using RestoLux.Application.Services;
using RestoLux.Application.Validators;

namespace RestoLux.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<CreateRestaurantDtoValidator>();

        services.AddScoped<IRestaurantService, RestaurantService>();
        services.AddScoped<IBranchService, BranchService>();
        services.AddScoped<IMenuService, MenuService>();
        services.AddScoped<IMenuCategoryService, MenuCategoryService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IReservationService, ReservationService>();
        services.AddScoped<IReviewService, ReviewService>();
        services.AddScoped<IAllergenService, AllergenService>();
        services.AddScoped<IDietaryTagService, DietaryTagService>();
        services.AddScoped<ITaxRuleService, TaxRuleService>();
        services.AddScoped<IDiningAreaService, DiningAreaService>();
        services.AddScoped<IDiningTableService, DiningTableService>();
        services.AddScoped<IOpeningHourService, OpeningHourService>();
        services.AddScoped<ISpecialClosureService, SpecialClosureService>();
        services.AddScoped<IContentPageService, ContentPageService>();
        services.AddScoped<ISiteSettingService, SiteSettingService>();
        services.AddScoped<IModifierGroupService, ModifierGroupService>();
        services.AddScoped<IModifierOptionService, ModifierOptionService>();
        services.AddScoped<IProductVariantService, ProductVariantService>();
        services.AddScoped<IProductImageService, ProductImageService>();
        services.AddScoped<IBranchProductAvailabilityService, BranchProductAvailabilityService>();
        services.AddScoped<INotificationTemplateService, NotificationTemplateService>();

        return services;
    }
}