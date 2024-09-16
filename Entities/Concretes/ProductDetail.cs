using Core.Entities;

namespace Entities.Concretes;

public class ProductDetail : Entity<Guid>
{
    public Guid ProductId { get; set; }
    public decimal UnitPrice { get; set; }
    public int UnitsInStock { get; set; }

    public virtual Product Product { get; set; }
    public virtual ICollection<ProductAttributeValue> ProductAttributeValues { get; set; } // Ürün özellikleri burada olacak
}
