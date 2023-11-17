using Microsoft.EntityFrameworkCore;

namespace Common.Extensions;

public static class PaginationExtension
{
    public static (List<T> entities, int count) Paginate<T>(this IQueryable<T> query, int page, int pageSize, bool pagination)
        where T : class =>

        new(!pagination ? query.ToList() : query.Skip((page - 1) * pageSize).Take(pageSize).ToList(), query.Count());

    public static async Task<(List<T> entities, int count)> PaginateAsync<T>(this IQueryable<T> query, int page, int pageSize, bool pagination)
        where T : class =>
        new(!pagination ? await query.ToListAsync() : await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(), await query.CountAsync());
}