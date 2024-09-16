using Core.Entities;

namespace Entities.Concretes;

public class ProductAttribute : Entity<Guid>
{
    public string Name { get; set; }  // Özellik adı (örneğin: RAM, Renk, Hafıza)
}
