using Business.Dtos.Requests.AddressRequests;
using Business.Dtos.Requests.BrandRequests;
using Business.Dtos.Responses.AddressResponses;
using Business.Dtos.Responses.BrandResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IBrandService
{
    Task<CreatedBrandResponse> AddAsync(CreateBrandRequest createBrandRequest);
    Task<UpdatedBrandResponse> UpdateAsync(UpdateBrandRequest updateBrandRequest);
    Task<DeletedBrandResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListBrandResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetBrandResponse> GetByIdAsync(Guid id);
}
