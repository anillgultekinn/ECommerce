namespace Business.Dtos.Responses.ProductAttributeValueResponses;

public class GetListProductAttributeValueResponse
{
    public Guid Id { get; set; }
    public Guid ProductDetailId { get; set; }
    public Guid ProductAttributeId { get; set; }
    public string ProductAttributeName { get; set; }
    public string Value { get; set; }
}
