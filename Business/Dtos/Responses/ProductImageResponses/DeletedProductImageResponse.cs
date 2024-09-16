namespace Business.Dtos.Responses.ProductImageResponses;

public class DeletedProductImageResponse
{
    public Guid ProductId { get; set; }
    public Guid Id { get; set; }
    public string ImageUrl { get; set; }
}
