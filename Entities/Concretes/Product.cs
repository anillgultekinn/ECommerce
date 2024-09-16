using Core.Entities;

namespace Entities.Concretes;

public class Product : Entity<Guid>
{
    public Guid BrandId { get; set; }
    public Guid CategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public Category Category { get; set; }
    public Brand Brand { get; set; }
    public virtual ICollection<ProductDetail> ProductDetails { get; set; }
    public virtual ICollection<ProductImage> ProductImages { get; set; }
}