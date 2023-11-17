using Application.Models.Dtos.Products;
using Common.Dtos;
using MediatR;

namespace Application.Models.Queries.Products;

public class GetProductByIdQuery : IRequest<ResultDto<ProductDto>>
{
    public int Id { get; set; }
}