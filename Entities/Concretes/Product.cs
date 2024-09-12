using Core.Entities;

namespace Entities.Concretes;

public class Product : Entity<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public Guid BrandId { get; set; }
    public Guid ColorId { get; set; }
    public Guid SizeId { get; set; }
    public Guid GenderId { get; set; }
    public decimal Price { get; set; }

    public Category Category { get; set; }
    public Brand Brand { get; set; }
    public Color Color { get; set; }
    public Size Size { get; set; }
    public Gender Gender { get; set; }
    public string ImageUrl { get; set; }

}
