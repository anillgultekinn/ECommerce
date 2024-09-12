using Business.Dtos.Requests.GenderRequests;
using Business.Dtos.Responses.GenderResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IGenderService
{
    Task<CreatedGenderResponse> AddAsync(CreateGenderRequest createGenderRequest);
    Task<UpdatedGenderResponse> UpdateAsync(UpdateGenderRequest updateGenderRequest);
    Task<DeletedGenderResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListGenderResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetGenderResponse> GetByIdAsync(Guid id);
}
