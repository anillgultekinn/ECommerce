namespace Business.Dtos.Requests.ProductDetailRequests;

public class CreateProductDetailRequest
{
    public Guid ProductId { get; set; }
    public Guid ProductAttributeId { get; set; }  
    public string Value { get; set; }  
    public decimal UnitPrice { get; set; }
    public int UnitsInStock { get; set; }
}
