using Business.Dtos.Requests.ColorRequests;
using Business.Dtos.Responses.ColorResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IColorService
{
    Task<CreatedColorResponse> AddAsync(CreateColorRequest createColorRequest);
    Task<UpdatedColorResponse> UpdateAsync(UpdateColorRequest updateColorRequest);
    Task<DeletedColorResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListColorResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetColorResponse> GetByIdAsync(Guid id);
}
