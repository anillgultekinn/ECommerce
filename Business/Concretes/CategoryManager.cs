using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.CategoryRequests;
using Business.Dtos.Responses.CategoryResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class CategoryManager : ICategoryService
{
    ICategoryDal _categoryDal;
    IMapper _mapper;
    CategoryBusinessRules _categoryBusinessRules;

    public CategoryManager(ICategoryDal categoryDal, IMapper mapper, CategoryBusinessRules categoryBusinessRules)
    {
        _categoryDal = categoryDal;
        _mapper = mapper;
        _categoryBusinessRules = categoryBusinessRules;
    }

    public async Task<CreatedCategoryResponse> AddAsync(CreateCategoryRequest createCategoryRequest)
    {
        Category category= _mapper.Map<Category>(createCategoryRequest);
        Category createdCategory = await _categoryDal.AddAsync(category);
        CreatedCategoryResponse createdCategoryResponse = _mapper.Map<CreatedCategoryResponse>(createdCategory);
        return createdCategoryResponse;
    }

    public async Task<DeletedCategoryResponse> DeleteAsync(Guid id)
    {
        await _categoryBusinessRules.IsExistsCategory(id);

        Category category = await _categoryDal.GetAsync(predicate: c => c.Id == id);
        Category deletedCategory = await _categoryDal.DeleteAsync(category);
        DeletedCategoryResponse deletedCategoryResponse = _mapper.Map<DeletedCategoryResponse>(deletedCategory);
        return deletedCategoryResponse;
    }

    public async Task<GetCategoryResponse> GetByIdAsync(Guid id)
    {
        var category = await _categoryDal.GetAsync(predicate: c => c.Id == id);
        var mappedCategory = _mapper.Map<GetCategoryResponse>(category);
        return mappedCategory;
    }

    public async Task<IPaginate<GetListCategoryResponse>> GetListAsync(PageRequest pageRequest)
    {

        var categories = await _categoryDal.GetListAsync(
           index: pageRequest.PageIndex,
           size: pageRequest.PageSize);
        var mappedCategories = _mapper.Map<Paginate<GetListCategoryResponse>>(categories);
        return mappedCategories;
    }

    public async Task<UpdatedCategoryResponse> UpdateAsync(UpdateCategoryRequest updateCategoryRequest)
    {
        await _categoryBusinessRules.IsExistsCategory(updateCategoryRequest.Id);

        Category category = _mapper.Map<Category>(updateCategoryRequest);
        Category updatedCategory = await _categoryDal.UpdateAsync(category);
        UpdatedCategoryResponse updatedCategoryResponse = _mapper.Map<UpdatedCategoryResponse>(updatedCategory);
        return updatedCategoryResponse;
    }
}
