using Core.Entities;

namespace Entities.Concretes;

public class ProductImage : Entity<Guid>
{
    public Guid ProductId { get; set; }
    public string ImageUrl { get; set; }

    public Product Product { get; set; }
}
