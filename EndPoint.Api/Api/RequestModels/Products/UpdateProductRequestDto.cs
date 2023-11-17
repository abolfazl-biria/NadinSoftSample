namespace EndPoint.Api.Api.RequestModels.Products;

public class UpdateProductRequestDto
{
    public bool IsAvailable { get; set; }
    public required string Name { get; set; }
    public required string ManufactureEmail { get; set; }
    public required string ManufacturePhone { get; set; }
    public DateTime ProduceDate { get; set; }
}