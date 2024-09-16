using Core.Entities;

namespace Entities.Concretes;

public class ProductAttributeValue : Entity<Guid>
{
    public Guid ProductDetailId { get; set; }
    public Guid ProductAttributeId { get; set; }  // Özellik (örneğin: RAM, Renk)
    public string Value { get; set; }  // Özelliğin değeri (örneğin: "16GB", "Kırmızı")

    public virtual ProductDetail ProductDetail { get; set; }
    public virtual ProductAttribute ProductAttribute { get; set; }
}
