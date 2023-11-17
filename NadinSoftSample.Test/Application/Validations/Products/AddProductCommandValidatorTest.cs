using Application.Models.Commands.Products;
using Application.Validators.Products;
using NadinSoftSample.Test.Application.DataProvider;

namespace NadinSoftSample.Test.Application.Validations.Products;

public class AddProductCommandValidatorTest
{
    private readonly AddProductCommandValidator _addProductCommandValidator;

    public AddProductCommandValidatorTest()
    {
        _addProductCommandValidator = new AddProductCommandValidator();
    }

    [Theory]
    [Trait("path", "Handler")]
    [MemberData(nameof(ProductDataProvider.Add), MemberType = typeof(ProductDataProvider))]
    public async void AddProductNameValidationFalse(AddProductCommand command)
    {
        command.Name =
            "111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111";

        var response = await _addProductCommandValidator.ValidateAsync(command, CancellationToken.None);

        Assert.True(response.Errors!.FirstOrDefault()!.PropertyName == "Name");
    }

    [Theory]
    [Trait("path", "Handler")]
    [MemberData(nameof(ProductDataProvider.Add), MemberType = typeof(ProductDataProvider))]
    public async void AddProductNameValidationTrue(AddProductCommand command)
    {
        command.Name =
            "12345";

        var response = await _addProductCommandValidator.ValidateAsync(command, CancellationToken.None);

        Assert.False(response.Errors?.FirstOrDefault()?.PropertyName == "Name");
    }

    [Theory]
    [Trait("path", "Handler")]
    [MemberData(nameof(ProductDataProvider.Add), MemberType = typeof(ProductDataProvider))]
    public async void AddProductManufactureEmailValidationFalse(AddProductCommand command)
    {
        command.ManufactureEmail =
            "adasdasd1245";

        var response = await _addProductCommandValidator.ValidateAsync(command, CancellationToken.None);

        Assert.True(response.Errors!.FirstOrDefault()!.PropertyName == "ManufactureEmail");
    }

    [Theory]
    [Trait("path", "Handler")]
    [MemberData(nameof(ProductDataProvider.Add), MemberType = typeof(ProductDataProvider))]
    public async void AddProductManufactureEmailValidationTrue(AddProductCommand command)
    {
        command.ManufactureEmail = "aaa@gmail.com";

        var response = await _addProductCommandValidator.ValidateAsync(command, CancellationToken.None);

        Assert.False(response.Errors?.FirstOrDefault()?.PropertyName == "ManufactureEmail");
    }


    [Theory]
    [Trait("path", "Handler")]
    [MemberData(nameof(ProductDataProvider.Add), MemberType = typeof(ProductDataProvider))]
    public async void AddProductManufacturePhoneValidationFalse(AddProductCommand command)
    {
        command.ManufacturePhone =
            "11111111111111111111111";

        var response = await _addProductCommandValidator.ValidateAsync(command, CancellationToken.None);

        Assert.True(response.Errors!.FirstOrDefault()!.PropertyName == "ManufacturePhone");
    }

    [Theory]
    [Trait("path", "Handler")]
    [MemberData(nameof(ProductDataProvider.Add), MemberType = typeof(ProductDataProvider))]
    public async void AddProductManufacturePhoneValidationTrue(AddProductCommand command)
    {
        command.ManufacturePhone = "12345678910";

        var response = await _addProductCommandValidator.ValidateAsync(command, CancellationToken.None);

        Assert.False(response.Errors?.FirstOrDefault()?.PropertyName == "ManufacturePhone");
    }

}