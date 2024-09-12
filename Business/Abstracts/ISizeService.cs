using Business.Dtos.Requests.SizeRequests;
using Business.Dtos.Responses.SizeResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface ISizeService
{
    Task<CreatedSizeResponse> AddAsync(CreateSizeRequest createSizeRequest);
    Task<UpdatedSizeResponse> UpdateAsync(UpdateSizeRequest updateSizeRequest);
    Task<DeletedSizeResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListSizeResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetSizeResponse> GetByIdAsync(Guid id);
}
