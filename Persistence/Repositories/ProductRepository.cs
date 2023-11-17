using Application.Interfaces.Repositories;
using Application.Models.Queries.Products;
using Common.Extensions;
using Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    private readonly IQueryable<Product> _queryable;

    public ProductRepository(AppDbContext dbContext) : base(dbContext)
    {
        _queryable = DbContext.Set<Product>();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        var query = _queryable;

        query = query
            .Include(x => x.Creator)
            .Include(x => x.Updater);

        return await query.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<(List<Product> products, int count)> GetByFilterAsync(ProductFilter filter)
    {
        var query = _queryable;

        query = query
            .Include(x => x.Creator)
            .Include(x => x.Updater);

        query = query.WhereIf(filter.CreatorId.HasValue, x => x.CreatorId == filter.CreatorId);

        query = query.AsNoTracking();

        return await query.PaginateAsync(filter.Page, filter.PageSize, filter.Pagination);
    }
}