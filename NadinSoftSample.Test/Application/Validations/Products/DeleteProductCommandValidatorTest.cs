using Application.Models.Commands.Products;
using Application.Validators.Products;
using NadinSoftSample.Test.Application.DataProvider;

namespace NadinSoftSample.Test.Application.Validations.Products;

public class DeleteProductCommandValidatorTest
{
    private readonly DeleteProductCommandValidator _deleteProductCommandValidator;

    public DeleteProductCommandValidatorTest()
    {
        _deleteProductCommandValidator = new DeleteProductCommandValidator();
    }

    [Theory]
    [Trait("path", "Handler")]
    [MemberData(nameof(ProductDataProvider.Delete), MemberType = typeof(ProductDataProvider))]
    public async void DeleteProductIdValidationFalse(DeleteProductCommand command)
    {
        command.Id = 0;

        var response = await _deleteProductCommandValidator.ValidateAsync(command, CancellationToken.None);

        Assert.True(response.Errors!.FirstOrDefault()!.PropertyName == "Id");
    }

    [Theory]
    [Trait("path", "Handler")]
    [MemberData(nameof(ProductDataProvider.Delete), MemberType = typeof(ProductDataProvider))]
    public async void DeleteProductIdValidationTrue(DeleteProductCommand command)
    {
        command.Id = 1;

        var response = await _deleteProductCommandValidator.ValidateAsync(command, CancellationToken.None);

        Assert.False(response.Errors?.FirstOrDefault()?.PropertyName == "Id");
    }
}