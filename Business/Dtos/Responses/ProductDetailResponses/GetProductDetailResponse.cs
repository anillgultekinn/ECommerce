using Entities.Concretes;

namespace Business.Dtos.Responses.ProductDetailResponses;

public class GetProductDetailResponse
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string ProductTitle { get; set; }
    public decimal UnitPrice { get; set; }
    public int UnitsInStock { get; set; }
}
