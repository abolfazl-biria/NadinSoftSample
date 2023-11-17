using System.ComponentModel.DataAnnotations;

namespace Common.Dtos;

public abstract class ResultBaseDto<TKey>
{
    [Display(Name = "شناسه")]
    public required TKey Id { get; set; }

    [Display(Name = "تاریخ ثبت")]
    public DateTime InsertTime { get; set; }

    [Display(Name = "تاریخ ویرایش")]
    public DateTime? UpdateTime { get; set; }

    [Display(Name = "وضعیت حذف")]
    public bool IsRemoved { get; set; }

    [Display(Name = "تاریخ حذف")]
    public DateTime? RemoveTime { get; set; }

    [Display(Name = "ایجاد کننده")]
    public string? CreatorName { get; set; }

    [Display(Name = "ایجاد کننده")]
    public int CreatorId { get; set; }

    [Display(Name = "آپدیت کننده")]
    public string? UpdaterName { get; set; }

    [Display(Name = "آپدیت کننده")]
    public int? UpdaterId { get; set; }
}

public abstract class ResultBaseDto : ResultBaseDto<int>
{
}