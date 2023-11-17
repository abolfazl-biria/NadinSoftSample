using Application.Models.Queries.Products;
using Domain.Entities.Products;

namespace Application.Interfaces.Repositories;

public interface IProductRepository : IRepository<Product>
{
    Task<Product?> GetByIdAsync(int id);
    Task<(List<Product> products, int count)> GetByFilterAsync(ProductFilter filter);
}