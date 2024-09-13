namespace Business.Dtos.Responses.ProductResponses;

public class CreatedProductResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public Guid BrandId { get; set; }
    public Guid ColorId { get; set; }
    public Guid SizeId { get; set; }
    public decimal Price { get; set; }
}
