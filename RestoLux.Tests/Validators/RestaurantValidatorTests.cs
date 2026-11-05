using FluentValidation.TestHelper;
using RestoLux.Application.DTOs;
using RestoLux.Application.Validators;

namespace RestoLux.Tests.Validators;

public class RestaurantValidatorTests
{
    private readonly CreateRestaurantDtoValidator _validator = new();

    [Fact]
    public void EmptyName_ShouldHaveValidationError()
    {
        var result = _validator.TestValidate(new CreateRestaurantDto(""));
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public void ValidDto_ShouldNotHaveValidationError()
    {
        var result = _validator.TestValidate(new CreateRestaurantDto("RestoLux"));
        result.ShouldNotHaveAnyValidationErrors();
    }
}