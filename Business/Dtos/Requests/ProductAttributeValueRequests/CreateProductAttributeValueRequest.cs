namespace Business.Dtos.Requests.ProductAttributeValueRequests;

public class CreateProductAttributeValueRequest
{
    public Guid ProductDetailId { get; set; }
    public Guid ProductAttributeId { get; set; }  
    public string Value { get; set; } 
}
