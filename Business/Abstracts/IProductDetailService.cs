using Business.Dtos.Requests.ProductDetailRequests;
using Business.Dtos.Responses.ProductDetailResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IProductDetailService
{
    Task<CreatedProductDetailResponse> AddAsync(CreateProductDetailRequest createProductDetailRequest);
    Task<UpdatedProductDetailResponse> UpdateAsync(UpdateProductDetailRequest updateProductDetailRequest);
    Task<DeletedProductDetailResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListProductDetailResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetProductDetailResponse> GetByIdAsync(Guid id);
}
