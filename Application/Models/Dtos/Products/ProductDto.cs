using Common.Dtos;

namespace Application.Models.Dtos.Products;

public class ProductDto : ResultBaseDto<int>
{
    public bool IsAvailable { get; set; }

    public required string Name { get; set; }
    public required string ManufactureEmail { get; set; }
    public required string ManufacturePhone { get; set; }
    public DateTime ProduceDate { get; set; }
}