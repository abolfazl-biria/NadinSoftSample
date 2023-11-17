using Domain.Entities.BaseEntities;
using Domain.Interfaces;

namespace Domain.Entities.Products;

public class Product : BaseEntity, IEntity
{
    public bool IsAvailable { get; set; }

    public required string Name { get; set; }
    public required string ManufactureEmail { get; set; }
    public required string ManufacturePhone { get; set; }
    public DateTime ProduceDate { get; set; }
}