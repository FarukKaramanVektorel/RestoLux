using FluentValidation;
using RestoLux.Application.DTOs;

namespace RestoLux.Application.Validators;

public class CreateRestaurantDtoValidator : AbstractValidator<CreateRestaurantDto>
{
    public CreateRestaurantDtoValidator() { RuleFor(x => x.Name).NotEmpty().MaximumLength(200); }
}
public class UpdateRestaurantDtoValidator : AbstractValidator<UpdateRestaurantDto>
{
    public UpdateRestaurantDtoValidator() { RuleFor(x => x.Name).NotEmpty().MaximumLength(200); }
}

public class CreateBranchDtoValidator : AbstractValidator<CreateBranchDto>
{
    public CreateBranchDtoValidator() { RuleFor(x => x.Name).NotEmpty(); RuleFor(x => x.RestaurantId).GreaterThan(0); RuleFor(x => x.Capacity).GreaterThanOrEqualTo(0); }
}
public class UpdateBranchDtoValidator : AbstractValidator<UpdateBranchDto>
{
    public UpdateBranchDtoValidator() { RuleFor(x => x.Name).NotEmpty(); RuleFor(x => x.RestaurantId).GreaterThan(0); RuleFor(x => x.Capacity).GreaterThanOrEqualTo(0); }
}

public class CreateMenuDtoValidator : AbstractValidator<CreateMenuDto>
{
    public CreateMenuDtoValidator() { RuleFor(x => x.Name).NotEmpty(); RuleFor(x => x.BranchId).GreaterThan(0); }
}
public class UpdateMenuDtoValidator : AbstractValidator<UpdateMenuDto>
{
    public UpdateMenuDtoValidator() { RuleFor(x => x.Name).NotEmpty(); RuleFor(x => x.BranchId).GreaterThan(0); }
}

public class CreateMenuCategoryDtoValidator : AbstractValidator<CreateMenuCategoryDto>
{
    public CreateMenuCategoryDtoValidator() { RuleFor(x => x.Name).NotEmpty(); RuleFor(x => x.MenuId).GreaterThan(0); }
}
public class UpdateMenuCategoryDtoValidator : AbstractValidator<UpdateMenuCategoryDto>
{
    public UpdateMenuCategoryDtoValidator() { RuleFor(x => x.Name).NotEmpty(); RuleFor(x => x.MenuId).GreaterThan(0); }
}

public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
{
    public CreateProductDtoValidator() { RuleFor(x => x.Name).NotEmpty(); RuleFor(x => x.CategoryId).GreaterThan(0); RuleFor(x => x.Price).GreaterThanOrEqualTo(0); }
}
public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
{
    public UpdateProductDtoValidator() { RuleFor(x => x.Name).NotEmpty(); RuleFor(x => x.CategoryId).GreaterThan(0); RuleFor(x => x.Price).GreaterThanOrEqualTo(0); }
}

public class CreateCustomerDtoValidator : AbstractValidator<CreateCustomerDto>
{
    public CreateCustomerDtoValidator() { RuleFor(x => x.FirstName).NotEmpty(); RuleFor(x => x.LastName).NotEmpty(); }
}
public class UpdateCustomerDtoValidator : AbstractValidator<UpdateCustomerDto>
{
    public UpdateCustomerDtoValidator() { RuleFor(x => x.FirstName).NotEmpty(); RuleFor(x => x.LastName).NotEmpty(); }
}

public class CreateReservationDtoValidator : AbstractValidator<CreateReservationDto>
{
    public CreateReservationDtoValidator() { RuleFor(x => x.GuestCount).GreaterThan(0); RuleFor(x => x.BranchId).GreaterThan(0); RuleFor(x => x.CustomerId).GreaterThan(0); }
}
public class UpdateReservationDtoValidator : AbstractValidator<UpdateReservationDto>
{
    public UpdateReservationDtoValidator() { RuleFor(x => x.GuestCount).GreaterThan(0); RuleFor(x => x.BranchId).GreaterThan(0); RuleFor(x => x.CustomerId).GreaterThan(0); }
}

public class CreateReviewDtoValidator : AbstractValidator<CreateReviewDto>
{
    public CreateReviewDtoValidator() { RuleFor(x => x.AuthorName).NotEmpty(); RuleFor(x => x.Rating).InclusiveBetween(1, 5); RuleFor(x => x.BranchId).GreaterThan(0); }
}
public class UpdateReviewDtoValidator : AbstractValidator<UpdateReviewDto>
{
    public UpdateReviewDtoValidator() { RuleFor(x => x.AuthorName).NotEmpty(); RuleFor(x => x.Rating).InclusiveBetween(1, 5); RuleFor(x => x.BranchId).GreaterThan(0); }
}

public class CreateAllergenDtoValidator : AbstractValidator<CreateAllergenDto> { public CreateAllergenDtoValidator() { RuleFor(x => x.Name).NotEmpty(); } }
public class UpdateAllergenDtoValidator : AbstractValidator<UpdateAllergenDto> { public UpdateAllergenDtoValidator() { RuleFor(x => x.Name).NotEmpty(); } }

public class CreateDietaryTagDtoValidator : AbstractValidator<CreateDietaryTagDto> { public CreateDietaryTagDtoValidator() { RuleFor(x => x.Name).NotEmpty(); } }
public class UpdateDietaryTagDtoValidator : AbstractValidator<UpdateDietaryTagDto> { public UpdateDietaryTagDtoValidator() { RuleFor(x => x.Name).NotEmpty(); } }

public class CreateTaxRuleDtoValidator : AbstractValidator<CreateTaxRuleDto> { public CreateTaxRuleDtoValidator() { RuleFor(x => x.Name).NotEmpty(); RuleFor(x => x.TaxPercentage).GreaterThanOrEqualTo(0); } }
public class UpdateTaxRuleDtoValidator : AbstractValidator<UpdateTaxRuleDto> { public UpdateTaxRuleDtoValidator() { RuleFor(x => x.Name).NotEmpty(); RuleFor(x => x.TaxPercentage).GreaterThanOrEqualTo(0); } }

public class CreateDiningAreaDtoValidator : AbstractValidator<CreateDiningAreaDto> { public CreateDiningAreaDtoValidator() { RuleFor(x => x.Name).NotEmpty(); RuleFor(x => x.BranchId).GreaterThan(0); RuleFor(x => x.Capacity).GreaterThan(0); } }
public class UpdateDiningAreaDtoValidator : AbstractValidator<UpdateDiningAreaDto> { public UpdateDiningAreaDtoValidator() { RuleFor(x => x.Name).NotEmpty(); RuleFor(x => x.BranchId).GreaterThan(0); RuleFor(x => x.Capacity).GreaterThan(0); } }

public class CreateDiningTableDtoValidator : AbstractValidator<CreateDiningTableDto> { public CreateDiningTableDtoValidator() { RuleFor(x => x.TableNumber).NotEmpty(); RuleFor(x => x.DiningAreaId).GreaterThan(0); RuleFor(x => x.MaxCapacity).GreaterThan(0); } }
public class UpdateDiningTableDtoValidator : AbstractValidator<UpdateDiningTableDto> { public UpdateDiningTableDtoValidator() { RuleFor(x => x.TableNumber).NotEmpty(); RuleFor(x => x.DiningAreaId).GreaterThan(0); RuleFor(x => x.MaxCapacity).GreaterThan(0); } }

public class CreateOpeningHourDtoValidator : AbstractValidator<CreateOpeningHourDto> { public CreateOpeningHourDtoValidator() { RuleFor(x => x.BranchId).GreaterThan(0); } }
public class UpdateOpeningHourDtoValidator : AbstractValidator<UpdateOpeningHourDto> { public UpdateOpeningHourDtoValidator() { RuleFor(x => x.BranchId).GreaterThan(0); } }

public class CreateSpecialClosureDtoValidator : AbstractValidator<CreateSpecialClosureDto> { public CreateSpecialClosureDtoValidator() { RuleFor(x => x.BranchId).GreaterThan(0); } }
public class UpdateSpecialClosureDtoValidator : AbstractValidator<UpdateSpecialClosureDto> { public UpdateSpecialClosureDtoValidator() { RuleFor(x => x.BranchId).GreaterThan(0); } }

public class CreateContentPageDtoValidator : AbstractValidator<CreateContentPageDto> { public CreateContentPageDtoValidator() { RuleFor(x => x.Title).NotEmpty(); RuleFor(x => x.Slug).NotEmpty(); RuleFor(x => x.RestaurantId).GreaterThan(0); } }
public class UpdateContentPageDtoValidator : AbstractValidator<UpdateContentPageDto> { public UpdateContentPageDtoValidator() { RuleFor(x => x.Title).NotEmpty(); RuleFor(x => x.Slug).NotEmpty(); RuleFor(x => x.RestaurantId).GreaterThan(0); } }

public class CreateSiteSettingDtoValidator : AbstractValidator<CreateSiteSettingDto> { public CreateSiteSettingDtoValidator() { RuleFor(x => x.Key).NotEmpty(); RuleFor(x => x.Value).NotEmpty(); RuleFor(x => x.RestaurantId).GreaterThan(0); } }
public class UpdateSiteSettingDtoValidator : AbstractValidator<UpdateSiteSettingDto> { public UpdateSiteSettingDtoValidator() { RuleFor(x => x.Key).NotEmpty(); RuleFor(x => x.Value).NotEmpty(); RuleFor(x => x.RestaurantId).GreaterThan(0); } }

public class CreateModifierGroupDtoValidator : AbstractValidator<CreateModifierGroupDto> { public CreateModifierGroupDtoValidator() { RuleFor(x => x.Name).NotEmpty(); RuleFor(x => x.ProductId).GreaterThan(0); } }
public class UpdateModifierGroupDtoValidator : AbstractValidator<UpdateModifierGroupDto> { public UpdateModifierGroupDtoValidator() { RuleFor(x => x.Name).NotEmpty(); RuleFor(x => x.ProductId).GreaterThan(0); } }

public class CreateModifierOptionDtoValidator : AbstractValidator<CreateModifierOptionDto> { public CreateModifierOptionDtoValidator() { RuleFor(x => x.Name).NotEmpty(); RuleFor(x => x.ModifierGroupId).GreaterThan(0); } }
public class UpdateModifierOptionDtoValidator : AbstractValidator<UpdateModifierOptionDto> { public UpdateModifierOptionDtoValidator() { RuleFor(x => x.Name).NotEmpty(); RuleFor(x => x.ModifierGroupId).GreaterThan(0); } }

public class CreateProductVariantDtoValidator : AbstractValidator<CreateProductVariantDto> { public CreateProductVariantDtoValidator() { RuleFor(x => x.Name).NotEmpty(); RuleFor(x => x.ProductId).GreaterThan(0); } }
public class UpdateProductVariantDtoValidator : AbstractValidator<UpdateProductVariantDto> { public UpdateProductVariantDtoValidator() { RuleFor(x => x.Name).NotEmpty(); RuleFor(x => x.ProductId).GreaterThan(0); } }

public class CreateProductImageDtoValidator : AbstractValidator<CreateProductImageDto> { public CreateProductImageDtoValidator() { RuleFor(x => x.Url).NotEmpty(); RuleFor(x => x.ProductId).GreaterThan(0); } }
public class UpdateProductImageDtoValidator : AbstractValidator<UpdateProductImageDto> { public UpdateProductImageDtoValidator() { RuleFor(x => x.Url).NotEmpty(); RuleFor(x => x.ProductId).GreaterThan(0); } }

public class CreateBranchProductAvailabilityDtoValidator : AbstractValidator<CreateBranchProductAvailabilityDto> { public CreateBranchProductAvailabilityDtoValidator() { RuleFor(x => x.BranchId).GreaterThan(0); RuleFor(x => x.ProductId).GreaterThan(0); } }
public class UpdateBranchProductAvailabilityDtoValidator : AbstractValidator<UpdateBranchProductAvailabilityDto> { public UpdateBranchProductAvailabilityDtoValidator() { RuleFor(x => x.BranchId).GreaterThan(0); RuleFor(x => x.ProductId).GreaterThan(0); } }

public class CreateNotificationTemplateDtoValidator : AbstractValidator<CreateNotificationTemplateDto> { public CreateNotificationTemplateDtoValidator() { RuleFor(x => x.TemplateName).NotEmpty(); RuleFor(x => x.Body).NotEmpty(); } }
public class UpdateNotificationTemplateDtoValidator : AbstractValidator<UpdateNotificationTemplateDto> { public UpdateNotificationTemplateDtoValidator() { RuleFor(x => x.TemplateName).NotEmpty(); RuleFor(x => x.Body).NotEmpty(); } }