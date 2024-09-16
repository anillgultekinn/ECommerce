using Business.Dtos.Requests.ProductImageRequests;
using Business.Dtos.Responses.ProductImageResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IProductImageService
{
    Task<CreatedProductImageResponse> AddAsync(CreateProductImageRequest createProductImageRequest);
    Task<UpdatedProductImageResponse> UpdateAsync(UpdateProductImageRequest updateProductImageRequest);
    Task<DeletedProductImageResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListProductImageResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetProductImageResponse> GetByIdAsync(Guid id);
}
