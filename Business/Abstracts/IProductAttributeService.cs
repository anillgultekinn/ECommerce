using Business.Dtos.Requests.ProductAttributeRequests;
using Business.Dtos.Responses.ProductAttributeResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IProductAttributeService
{
    Task<CreatedProductAttributeResponse> AddAsync(CreateProductAttributeRequest createProductAttributeRequest);
    Task<UpdatedProductAttributeResponse> UpdateAsync(UpdateProductAttributeRequest updateProductAttributeRequest);
    Task<DeletedProductAttributeResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListProductAttributeResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetProductAttributeResponse> GetByIdAsync(Guid id);
}
