namespace Business.Dtos.Requests.ProductDetailRequests;

public class CreateProductDetailRequest
{
    public Guid ProductId { get; set; }
    public decimal UnitPrice { get; set; }
    public int UnitsInStock { get; set; }
}
