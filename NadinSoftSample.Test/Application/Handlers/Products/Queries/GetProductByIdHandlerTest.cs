using Application.Handlers.Products.Queries;
using Application.Interfaces;
using Application.Models.Dtos.Products;
using Application.Models.Queries.Products;
using AutoMapper;
using Common.Dtos;
using Domain.Entities.Products;
using Moq;

namespace NadinSoftSample.Test.Application.Handlers.Products.Queries;

public class GetProductHandlerTest
{
    private readonly Mock<IUnitOfWork> _unitOfWork;
    private readonly Mock<IMapper> _mapper;
    private readonly GetProductByIdHandler _getProductByIdHandler;

    public GetProductHandlerTest()
    {
        _unitOfWork = new Mock<IUnitOfWork>();
        _mapper = new Mock<IMapper>();
        _getProductByIdHandler = new GetProductByIdHandler(_unitOfWork.Object, _mapper.Object);
    }

    [Fact]
    [Trait("path", "Handler")]
    public async void GetProductSuccess()
    {
        var product = new Product()
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
        };

        var productDto = new ProductDto()
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
        };

        _unitOfWork.Setup(m => m.Products.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(product);

        _mapper.Setup(x => x.Map<ProductDto>(product)).Returns(productDto);

        var response = await _getProductByIdHandler.Handle(new GetProductByIdQuery()
        {
            Id = 1
        }, CancellationToken.None);

        Assert.IsType<ResultDto<ProductDto>>(response);
        Assert.IsType<ProductDto>(response.Data);
        Assert.True(response.IsSuccess);
        Assert.True(response.Data != null);
        Assert.Equal(1, response.Data.Id);

    }

    [Fact]
    [Trait("path", "Handler")]
    public async void GetNullProductSuccess()
    {
        _unitOfWork.Setup(m => m.Products.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(null as Product);

        _mapper.Setup(x => x.Map<ProductDto>(It.IsAny<Product>())).Returns(It.IsAny<ProductDto>());

        var response = await _getProductByIdHandler.Handle(new GetProductByIdQuery()
        {
            Id = 2
        }, CancellationToken.None);

        Assert.IsType<ResultDto<ProductDto>>(response);
        Assert.True(!response.IsSuccess);
        Assert.True(response.Data == null);
    }
}