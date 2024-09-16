namespace Business.Dtos.Requests.ProductDetailRequests;

public class UpdateProductDetailRequest
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public decimal UnitPrice { get; set; }
    public int UnitsInStock { get; set; }
}
