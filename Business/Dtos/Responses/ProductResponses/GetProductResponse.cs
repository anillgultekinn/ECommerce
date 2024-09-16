namespace Business.Dtos.Responses.ProductResponses;

public class GetProductResponse
{
    public Guid Id { get; set; }
    public Guid BrandId { get; set; }
    public string BrandName { get; set; }
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
