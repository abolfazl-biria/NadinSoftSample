using Common.Dtos;

namespace Application.Models.Queries.Products;

public class ProductFilter : PaginationDto
{
    public ProductFilter(int page, int pageSize, bool pagination = true) : base(page, pageSize, pagination)
    {

    }
    public int? CreatorId { get; set; }
}