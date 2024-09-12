using Core.Entities;

namespace Entities.Concretes;

public class Gender : Entity<Guid>
{
    public string Name { get; set; }

}
