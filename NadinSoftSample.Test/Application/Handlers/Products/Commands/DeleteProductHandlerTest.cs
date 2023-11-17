using Application.Handlers.Products.Commands;
using Application.Interfaces;
using Application.Models.Commands.Products;
using Common.Dtos;
using Domain.Entities.Products;
using Moq;
using NadinSoftSample.Test.Application.DataProvider;

namespace NadinSoftSample.Test.Application.Handlers.Products.Commands;

public class DeleteProductHandlerTest
{
    private readonly Mock<IUnitOfWork> _unitOfWork;
    private readonly DeleteProductHandler _deleteProductHandler;

    public DeleteProductHandlerTest()
    {
        _unitOfWork = new Mock<IUnitOfWork>();
        _deleteProductHandler = new DeleteProductHandler(_unitOfWork.Object);
    }

    [Theory]
    [Trait("path", "Handler")]
    [MemberData(nameof(ProductDataProvider.Delete), MemberType = typeof(ProductDataProvider))]
    public async void DeleteProduct(DeleteProductCommand command)
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

        var response = await _deleteProductHandler.Handle(command, CancellationToken.None);

        _unitOfWork.Verify(x => x.Products.Update(It.IsAny<Product>()), Times.Once);
        Assert.IsType<ResultDto>(response);
        Assert.True(response.IsSuccess);
    }

    [Theory]
    [Trait("path", "Handler")]
    [MemberData(nameof(ProductDataProvider.Delete), MemberType = typeof(ProductDataProvider))]
    public async void DeleteProductByOtherCreator(DeleteProductCommand command)
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

        var response = await _deleteProductHandler.Handle(command, CancellationToken.None);

        _unitOfWork.Verify(x => x.Products.Update(It.IsAny<Product>()), Times.Never);
        Assert.IsType<ResultDto>(response);
        Assert.True(!response.IsSuccess);
    }

    [Theory]
    [Trait("path", "Handler")]
    [MemberData(nameof(ProductDataProvider.Delete), MemberType = typeof(ProductDataProvider))]
    public async void DeleteDuplicateProduct(DeleteProductCommand command)
    {
        _unitOfWork.Setup(m => m.Products.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(null as Product);

        var response = await _deleteProductHandler.Handle(command, CancellationToken.None);

        Assert.IsType<ResultDto>(response);

        Assert.True(!response.IsSuccess);
    }
}