namespace Business.Dtos.Requests.ProductImageRequests;

public class CreateProductImageRequest
{
    public Guid ProductId { get; set; }
    public string ImageUrl { get; set; }
}
