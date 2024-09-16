namespace Business.Dtos.Requests.ProductRequests;

public class CreateProductRequest
{
    public Guid BrandId { get; set; }
    public Guid CategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
