namespace Business.Dtos.Requests.ProductAttributeValueRequests;

public class UpdateProductAttributeValueRequest
{
    public Guid Id { get; set; }
    public Guid ProductDetailId { get; set; }
    public Guid ProductAttributeId { get; set; }
    public string Value { get; set; }
}
