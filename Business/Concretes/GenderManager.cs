using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.GenderRequests;
using Business.Dtos.Responses.GenderResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class GenderManager : IGenderService
{
    IGenderDal _genderDal;
    IMapper _mapper;
    GenderBusinessRules _genderBusinessRules;
    public GenderManager(IGenderDal genderDal, IMapper mapper, GenderBusinessRules genderBusinessRules)
    {
        _genderDal = genderDal;
        _mapper = mapper;
        _genderBusinessRules = genderBusinessRules;
    }

    public async Task<CreatedGenderResponse> AddAsync(CreateGenderRequest createGenderRequest)
    {
        Gender gender = _mapper.Map<Gender>(createGenderRequest);
        Gender createdGender = await _genderDal.AddAsync(gender);
        CreatedGenderResponse createdGenderResponse = _mapper.Map<CreatedGenderResponse>(createdGender);
        return createdGenderResponse;
    }

    public async Task<DeletedGenderResponse> DeleteAsync(Guid id)
    {
        await _genderBusinessRules.IsExistsGender(id);
        Gender gender = await _genderDal.GetAsync(predicate: c => c.Id == id);
        Gender deletedGender = await _genderDal.DeleteAsync(gender);
        DeletedGenderResponse deletedGenderResponse = _mapper.Map<DeletedGenderResponse>(deletedGender);
        return deletedGenderResponse;
    }

    public async Task<GetGenderResponse> GetByIdAsync(Guid id)
    {
        var gender = await _genderDal.GetAsync(predicate: c => c.Id == id);
        var mappedGender = _mapper.Map<GetGenderResponse>(gender);
        return mappedGender;
    }

    public async Task<IPaginate<GetListGenderResponse>> GetListAsync(PageRequest pageRequest)
    {

        var genders = await _genderDal.GetListAsync(
           index: pageRequest.PageIndex,
           size: pageRequest.PageSize);
        var mappedGenders = _mapper.Map<Paginate<GetListGenderResponse>>(genders);
        return mappedGenders;
    }

    public async Task<UpdatedGenderResponse> UpdateAsync(UpdateGenderRequest updateGenderRequest)
    {
        await _genderBusinessRules.IsExistsGender(updateGenderRequest.Id);

        Gender gender = _mapper.Map<Gender>(updateGenderRequest);
        Gender updatedGender = await _genderDal.UpdateAsync(gender);
        UpdatedGenderResponse updatedGenderResponse = _mapper.Map<UpdatedGenderResponse>(updatedGender);
        return updatedGenderResponse;
    }
}
