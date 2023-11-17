using Application.Models.Dtos.Products;
using Common.Dtos;
using MediatR;

namespace Application.Models.Queries.Products;

public class GetProductsByFilterQuery : IRequest<ResultDto<List<ProductDto>>>
{
    public ProductFilter Filter { get; set; }
}