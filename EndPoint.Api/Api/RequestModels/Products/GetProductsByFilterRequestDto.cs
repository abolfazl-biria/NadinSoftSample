namespace EndPoint.Api.Api.RequestModels.Products;

public class GetProductsByFilterRequestDto
{
    public int? CreatorId { get; set; }

    public int PageSize { get; set; }
    public int Page { get; set; }
    public bool Pagination { get; set; } = true;
}