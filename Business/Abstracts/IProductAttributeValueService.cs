using Business.Dtos.Requests.ProductAttributeValueRequests;
using Business.Dtos.Responses.ProductAttributeValueResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IProductAttributeValueService
{
    Task<CreatedProductAttributeValueResponse> AddAsync(CreateProductAttributeValueRequest createProductAttributeValueRequest);
    Task<UpdatedProductAttributeValueResponse> UpdateAsync(UpdateProductAttributeValueRequest updateProductAttributeValueRequest);
    Task<DeletedProductAttributeValueResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListProductAttributeValueResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetProductAttributeValueResponse> GetByIdAsync(Guid id);
}
