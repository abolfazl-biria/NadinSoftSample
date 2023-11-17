using Application.Interfaces;
using Application.Models.Dtos.Products;
using Application.Models.Queries.Products;
using AutoMapper;
using Common.Dtos;
using MediatR;

namespace Application.Handlers.Products.Queries;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ResultDto<ProductDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetProductByIdHandler(IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResultDto<ProductDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(request.Id);

        if (product == null)
        {
            return new ResultDto<ProductDto>
            {
                IsSuccess = false,
                Message = $"محصول یافت نشد"
            };
        }

        var result = _mapper.Map<ProductDto>(product);

        return new ResultDto<ProductDto>
        {
            Data = result,
            IsSuccess = true,
            Message = "با موفقیت انجام شد"
        };
    }
}