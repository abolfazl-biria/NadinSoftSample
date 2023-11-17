using Application.Interfaces;
using Application.Models.Dtos.Products;
using Application.Models.Queries.Products;
using AutoMapper;
using Common.Dtos;
using MediatR;

namespace Application.Handlers.Products.Queries;

public class GetProductsByFilterHandler : IRequestHandler<GetProductsByFilterQuery, ResultDto<List<ProductDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetProductsByFilterHandler(IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResultDto<List<ProductDto>>> Handle(GetProductsByFilterQuery request, CancellationToken cancellationToken)
    {
        var (products, _) = await _unitOfWork.Products.GetByFilterAsync(request.Filter);

        var result = _mapper.Map<List<ProductDto>>(products);

        return new ResultDto<List<ProductDto>>
        {
            Data = result,
            IsSuccess = true,
            Message = "با موفقیت انجام شد",
        };
    }
}