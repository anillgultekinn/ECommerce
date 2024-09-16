using Business.Dtos.Responses.ProductAttributeValueResponses;
using Entities.Concretes;

namespace Business.Dtos.Responses.ProductDetailResponses;

public class GetListProductDetailResponse
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string ProductTitle { get; set; }
    public decimal UnitPrice { get; set; }
    public int UnitsInStock { get; set; }
    public ICollection<GetListProductAttributeValueResponse> ProductAttributeValues { get; set; }
}
