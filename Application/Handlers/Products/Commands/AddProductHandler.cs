using Application.Helper;
using Application.Interfaces;
using Application.Models.Commands.Products;
using Common.Dtos;
using MediatR;

namespace Application.Handlers.Products.Commands;

public class AddProductHandler : IRequestHandler<AddProductCommand, ResultDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddProductHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultDto> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {

        var productExist = await _unitOfWork.Products
            .ExistsAsync(x => x.ManufactureEmail == request.ManufactureEmail && x.ProduceDate == request.ProduceDate);

        if (productExist)
        {
            return new ResultDto
            {
                IsSuccess = false,
                Message = $"محصول از قبل موجود میباشد"
            };
        }

        var product = request.Create();

        _unitOfWork.Products.Add(product);
        await _unitOfWork.CommitAsync();

        return new ResultDto
        {
            IsSuccess = true,
            Message = "با موفقیت انجام شد"
        };
    }
}