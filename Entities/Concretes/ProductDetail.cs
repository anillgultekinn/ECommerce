using Core.Entities;

namespace Entities.Concretes;

public class ProductDetail : Entity<Guid>
{
    public Guid ProductId { get; set; }
    public Guid ProductAttributeId { get; set; }  // Özellik (örneğin RAM, Renk)
    public string Value { get; set; }  // Özelliğin değeri (örneğin 16GB, Kırmızı)
    public decimal UnitPrice { get; set; }
    public int UnitsInStock { get; set; }


    public virtual Product Product { get; set; }
    public virtual ProductAttribute ProductAttribute { get; set; } 
}
