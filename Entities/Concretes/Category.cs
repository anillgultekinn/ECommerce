using Core.Entities;

namespace Entities.Concretes;

public class Category : Entity<Guid>
{
    public Guid? ParentId { get; set; }
    public string Name { get; set; }
    public virtual Category Parent { get; set; }
}
