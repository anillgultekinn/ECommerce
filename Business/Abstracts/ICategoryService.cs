using Business.Dtos.Requests.CategoryRequests;
using Business.Dtos.Responses.CategoryResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface ICategoryService
{
    Task<CreatedCategoryResponse> AddAsync(CreateCategoryRequest createCategoryRequest);
    Task<UpdatedCategoryResponse> UpdateAsync(UpdateCategoryRequest updateCategoryRequest);
    Task<DeletedCategoryResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListCategoryResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetCategoryResponse> GetByIdAsync(Guid id);
}
