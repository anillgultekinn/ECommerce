namespace Business.Dtos.Responses.ProductDetailResponses;

public class CreatedProductDetailResponse
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public decimal UnitPrice { get; set; }
    public int UnitsInStock { get; set; }
}
