using Application.Models.Commands.Products;
using Application.Validators.Products;
using NadinSoftSample.Test.Application.DataProvider;

namespace NadinSoftSample.Test.Application.Validations.Products;

public class UpdateProductCommandValidatorTest
{
    private readonly UpdateProductCommandValidator _updateProductCommandValidator;

    public UpdateProductCommandValidatorTest()
    {
        _updateProductCommandValidator = new UpdateProductCommandValidator();
    }

    [Theory]
    [Trait("path", "Handler")]
    [MemberData(nameof(ProductDataProvider.Update), MemberType = typeof(ProductDataProvider))]
    public async void UpdateProductIdValidationFalse(UpdateProductCommand command)
    {
        command.Id = 0;

        var response = await _updateProductCommandValidator.ValidateAsync(command, CancellationToken.None);

        Assert.True(response.Errors!.FirstOrDefault()!.PropertyName == "Id");
    }

    [Theory]
    [Trait("path", "Handler")]
    [MemberData(nameof(ProductDataProvider.Update), MemberType = typeof(ProductDataProvider))]
    public async void UpdateProductIdValidationTrue(UpdateProductCommand command)
    {
        command.Id = 1;

        var response = await _updateProductCommandValidator.ValidateAsync(command, CancellationToken.None);

        Assert.False(response.Errors?.FirstOrDefault()?.PropertyName == "Id");
    }

    [Theory]
    [Trait("path", "Handler")]
    [MemberData(nameof(ProductDataProvider.Update), MemberType = typeof(ProductDataProvider))]
    public async void UpdateProductNameValidationFalse(UpdateProductCommand command)
    {
        command.Name =
            "111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111";

        var response = await _updateProductCommandValidator.ValidateAsync(command, CancellationToken.None);

        Assert.True(response.Errors!.FirstOrDefault()!.PropertyName == "Name");
    }

    [Theory]
    [Trait("path", "Handler")]
    [MemberData(nameof(ProductDataProvider.Update), MemberType = typeof(ProductDataProvider))]
    public async void UpdateProductNameValidationTrue(UpdateProductCommand command)
    {
        command.Name =
            "12345";

        var response = await _updateProductCommandValidator.ValidateAsync(command, CancellationToken.None);

        Assert.False(response.Errors?.FirstOrDefault()?.PropertyName == "Name");
    }

    [Theory]
    [Trait("path", "Handler")]
    [MemberData(nameof(ProductDataProvider.Update), MemberType = typeof(ProductDataProvider))]
    public async void UpdateProductManufactureEmailValidationFalse(UpdateProductCommand command)
    {
        command.ManufactureEmail =
            "adasdasd1245";

        var response = await _updateProductCommandValidator.ValidateAsync(command, CancellationToken.None);

        Assert.True(response.Errors!.FirstOrDefault()!.PropertyName == "ManufactureEmail");
    }

    [Theory]
    [Trait("path", "Handler")]
    [MemberData(nameof(ProductDataProvider.Update), MemberType = typeof(ProductDataProvider))]
    public async void UpdateProductManufactureEmailValidationTrue(UpdateProductCommand command)
    {
        command.ManufactureEmail = "aaa@gmail.com";

        var response = await _updateProductCommandValidator.ValidateAsync(command, CancellationToken.None);

        Assert.False(response.Errors?.FirstOrDefault()?.PropertyName == "ManufactureEmail");
    }


    [Theory]
    [Trait("path", "Handler")]
    [MemberData(nameof(ProductDataProvider.Update), MemberType = typeof(ProductDataProvider))]
    public async void UpdateProductManufacturePhoneValidationFalse(UpdateProductCommand command)
    {
        command.ManufacturePhone =
            "11111111111111111111111";

        var response = await _updateProductCommandValidator.ValidateAsync(command, CancellationToken.None);

        Assert.True(response.Errors!.FirstOrDefault()!.PropertyName == "ManufacturePhone");
    }

    [Theory]
    [Trait("path", "Handler")]
    [MemberData(nameof(ProductDataProvider.Update), MemberType = typeof(ProductDataProvider))]
    public async void UpdateProductManufacturePhoneValidationTrue(UpdateProductCommand command)
    {
        command.ManufacturePhone = "12345678910";

        var response = await _updateProductCommandValidator.ValidateAsync(command, CancellationToken.None);

        Assert.False(response.Errors?.FirstOrDefault()?.PropertyName == "ManufacturePhone");
    }
}