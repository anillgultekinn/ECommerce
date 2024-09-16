namespace Business.Dtos.Requests.ProductImageRequests;

public class UpdateProductImageRequest
{
    public Guid ProductId { get; set; }
    public Guid Id { get; set; }
    public string ImageUrl { get; set; }
}
