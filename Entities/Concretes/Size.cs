using Core.Entities;

namespace Entities.Concretes;

public class Size : Entity<Guid>
{
    public string Name { get; set; }

    public virtual ICollection<Product>? Products { get; set; }

}
