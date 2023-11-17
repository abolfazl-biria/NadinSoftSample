namespace Common.Dtos;

public abstract class PaginationDto
{
    private const int MinPageNumber = 1;
    private const int MaxPageSize = 200;

    protected PaginationDto(int page, int pageSize, bool pagination = true)
    {
        Page = page > 0 ? page : MinPageNumber;
        PageSize = pageSize > 0 ? pageSize : MaxPageSize;
        Pagination = pagination;
    }

    public bool Pagination { get; }
    public int Page { get; }
    public int PageSize { get; }
}