using Application.Handlers.Products.Commands;
using Application.Interfaces;
using Application.Models.Commands.Products;
using Common.Dtos;
using Domain.Entities.Products;
using Moq;
using NadinSoftSample.Test.Application.DataProvider;
using System.Linq.Expressions;

namespace NadinSoftSample.Test.Application.Handlers.Products.Commands;

public class AddProductHandlerTest
{
    private readonly Mock<IUnitOfWork> _unitOfWork;
    private readonly AddProductHandler _addProductHandler;

    public AddProductHandlerTest()
    {
        _unitOfWork = new Mock<IUnitOfWork>();
        _addProductHandler = new AddProductHandler(_unitOfWork.Object);
    }

    [Theory]
    [Trait("path", "Handler")]
    [MemberData(nameof(ProductDataProvider.Add), MemberType = typeof(ProductDataProvider))]
    public async void AddProduct(AddProductCommand command)
    {
        _unitOfWork.Setup(m => m.Products.ExistsAsync(It.IsAny<Expression<Func<Product, bool>>>())).ReturnsAsync(false);

        var response = await _addProductHandler.Handle(command, CancellationToken.None);

        _unitOfWork.Verify(x => x.Products.Add(It.IsAny<Product>()), Times.Once);
        Assert.IsType<ResultDto>(response);
        Assert.True(response.IsSuccess);
    }

    [Theory]
    [Trait("path", "Handler")]
    [MemberData(nameof(ProductDataProvider.Add), MemberType = typeof(ProductDataProvider))]
    public async void AddDuplicateProduct(AddProductCommand command)
    {
        _unitOfWork.Setup(m => m.Products.ExistsAsync(It.IsAny<Expression<Func<Product, bool>>>())).ReturnsAsync(true);

        var response = await _addProductHandler.Handle(command, CancellationToken.None);

        Assert.IsType<ResultDto>(response);

        Assert.True(!response.IsSuccess);
    }
}