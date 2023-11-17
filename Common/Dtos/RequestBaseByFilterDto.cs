using System.ComponentModel.DataAnnotations;

namespace Common.Dtos;

public abstract class RequestBaseByFilterDto<TKey> : PaginationDto
{
    protected RequestBaseByFilterDto(int page, int pageSize, bool pagination = true) : base(page, pageSize, pagination)
    {
    }

    [Display(Name = "شناسه")]
    public TKey? Id { get; set; }

    [Display(Name = "تاریخ ثبت از")]
    public DateTime? StartInsertTime { get; set; }

    [Display(Name = "تاریخ ثبت تا")]
    public DateTime? EndInsertTime { get; set; }

    [Display(Name = "ایجاد کننده")]
    public int? CreatorId { get; set; }

    [Display(Name = "آپدیت کننده")]
    public int? UpdaterId { get; set; }

    [Display(Name = "وضعیت حذف")]
    public bool? IsRemoved { get; set; }

}

public abstract class RequestBaseByFilterDto : RequestBaseByFilterDto<int?>
{
    protected RequestBaseByFilterDto(int page, int pageSize, bool pagination = true) : base(page, pageSize, pagination)
    {
    }
}