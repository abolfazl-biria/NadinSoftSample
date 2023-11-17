using Application.Helper;
using Application.Interfaces;
using Application.Models.Commands.Products;
using Common.Dtos;
using MediatR;

namespace Application.Handlers.Products.Commands;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ResultDto>
{
    private readonly IUnitOfWork _unitOfWork;
    public UpdateProductHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(request.Id);

        if (product == null)
        {
            return new ResultDto
            {
                IsSuccess = false,
                Message = $"اکانت شما یافت نشد"
            };
        }

        if (product.CreatorId != request.UserInfo.UserId)
        {
            return new ResultDto
            {
                IsSuccess = false,
                Message = $"عدم دسترسی"
            };
        }

        var productExist = await _unitOfWork.Products
            .ExistsAsync(x => x.ManufactureEmail == request.ManufactureEmail && x.ProduceDate == request.ProduceDate && x.Id != product.Id);

        if (productExist)
        {
            return new ResultDto
            {
                IsSuccess = false,
                Message = $"محصول از قبل موجود میباشد"
            };
        }

        product.Update(request);

        _unitOfWork.Products.Update(product);
        await _unitOfWork.CommitAsync();

        return new ResultDto
        {
            IsSuccess = true,
            Message = "با موفقیت انجام شد"
        };
    }
}