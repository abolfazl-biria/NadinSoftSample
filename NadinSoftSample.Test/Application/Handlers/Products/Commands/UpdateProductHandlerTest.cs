using Application.Handlers.Products.Commands;
using Application.Interfaces;
using Application.Models.Commands.Products;
using Common.Dtos;
using Domain.Entities.Products;
using Moq;
using NadinSoftSample.Test.Application.DataProvider;

namespace NadinSoftSample.Test.Application.Handlers.Products.Commands;

public class UpdateProductHandlerTest
{
    private readonly Mock<IUnitOfWork> _unitOfWork;
    private readonly UpdateProductHandler _updateProductHandler;

    public UpdateProductHandlerTest()
    {
        _unitOfWork = new Mock<IUnitOfWork>();
        _updateProductHandler = new UpdateProductHandler(_unitOfWork.Object);
    }

    [Theory]
    [Trait("path", "Handler")]
    [MemberData(nameof(ProductDataProvider.Update), MemberType = typeof(ProductDataProvider))]
    public async void UpdateProduct(UpdateProductCommand command)
    {
        _unitOfWork.Setup(m => m.Products.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(new Product()
        {
            ManufactureEmail = "aaa@gmail.com",
            ManufacturePhone = "12345678901",
            Name = "aa",
            ProduceDate = new DateTime(2022, 8, 1, 1, 1, 1),
            IsAvailable = true,
            Id = 1,
            CreatorId = 1,
            InsertTime = DateTime.Now,
            IsRemoved = false
        });

        var response = await _updateProductHandler.Handle(command, CancellationToken.None);

        _unitOfWork.Verify(x => x.Products.Update(It.IsAny<Product>()), Times.Once);
        Assert.IsType<ResultDto>(response);
        Assert.True(response.IsSuccess);
    }

    [Theory]
    [Trait("path", "Handler")]
    [MemberData(nameof(ProductDataProvider.Update), MemberType = typeof(ProductDataProvider))]
    public async void UpdateProductByOtherCreator(UpdateProductCommand command)
    {
        _unitOfWork.Setup(m => m.Products.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(new Product()
        {
            ManufactureEmail = "aaa@gmail.com",
            ManufacturePhone = "12345678901",
            Name = "aa",
            ProduceDate = new DateTime(2022, 8, 1, 1, 1, 1),
            IsAvailable = true,
            Id = 1,
            CreatorId = 2,
            InsertTime = DateTime.Now,
            IsRemoved = false
        });

        var response = await _updateProductHandler.Handle(command, CancellationToken.None);

        _unitOfWork.Verify(x => x.Products.Update(It.IsAny<Product>()), Times.Never);
        Assert.IsType<ResultDto>(response);
        Assert.True(!response.IsSuccess);
    }

    [Theory]
    [Trait("path", "Handler")]
    [MemberData(nameof(ProductDataProvider.Update), MemberType = typeof(ProductDataProvider))]
    public async void UpdateDuplicateProduct(UpdateProductCommand command)
    {
        _unitOfWork.Setup(m => m.Products.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(null as Product);

        var response = await _updateProductHandler.Handle(command, CancellationToken.None);

        Assert.IsType<ResultDto>(response);

        Assert.True(!response.IsSuccess);
    }
}