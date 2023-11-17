using Application.Interfaces;
using Application.Models.Commands.Products;
using Common.Dtos;
using MediatR;

namespace Application.Handlers.Products.Commands;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, ResultDto>
{
    private readonly IUnitOfWork _unitOfWork;
    public DeleteProductHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ResultDto> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(request.Id);

        if (product == null)
        {
            return new ResultDto
            {
                IsSuccess = false,
                Message = $"محصول یافت نشد"
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

        product.RemoveTime = DateTime.Now;
        product.IsRemoved = true;

        _unitOfWork.Products.Update(product);
        await _unitOfWork.CommitAsync();

        return new ResultDto
        {
            IsSuccess = true,
            Message = "با موفقیت حذف شد"
        };
    }
}