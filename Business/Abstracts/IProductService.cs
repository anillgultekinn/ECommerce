using Business.Dtos.Requests.ProductRequests;
using Business.Dtos.Responses.ProductResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IProductService
{
    Task<CreatedProductResponse> AddAsync(CreateProductRequest createProductRequest);
    Task<UpdatedProductResponse> UpdateAsync(UpdateProductRequest updateProductRequest);
    Task<DeletedProductResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListProductResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetProductResponse> GetByIdAsync(Guid id);
}
