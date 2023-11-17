using Domain.Entities.Users;

namespace Domain.Entities.BaseEntities;

public abstract class BaseEntity<TKey>
{
    public TKey Id { get; set; } = default!;

    public DateTime InsertTime { get; set; } = DateTime.UtcNow;

    public DateTime? UpdateTime { get; set; }

    public bool IsRemoved { get; set; } = false;

    public DateTime? RemoveTime { get; set; }


    public virtual MyUser Creator { get; set; }

    public int CreatorId { get; set; }

    public virtual MyUser? Updater { get; set; }

    public int? UpdaterId { get; set; }
}

public abstract class BaseEntity : BaseEntity<int>
{

}