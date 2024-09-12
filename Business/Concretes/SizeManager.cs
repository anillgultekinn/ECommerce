using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.SizeRequests;
using Business.Dtos.Responses.SizeResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class SizeManager : ISizeService
{
    ISizeDal _sizeDal;
    IMapper _mapper;
    SizeBusinessRules _sizeBusinessRules;

    public SizeManager(ISizeDal sizeDal, IMapper mapper, SizeBusinessRules sizeBusinessRules)
    {
        _sizeDal = sizeDal;
        _mapper = mapper;
        _sizeBusinessRules = sizeBusinessRules;
    }

    public async Task<CreatedSizeResponse> AddAsync(CreateSizeRequest createSizeRequest)
    {
        Size size = _mapper.Map<Size>(createSizeRequest);
        Size createdSize = await _sizeDal.AddAsync(size);
        CreatedSizeResponse createdSizeResponse = _mapper.Map<CreatedSizeResponse>(createdSize);
        return createdSizeResponse;
    }

    public async Task<DeletedSizeResponse> DeleteAsync(Guid id)
    {
        await _sizeBusinessRules.IsExistsSize(id);

        Size size = await _sizeDal.GetAsync(predicate: c => c.Id == id);
        Size deletedSize = await _sizeDal.DeleteAsync(size);
        DeletedSizeResponse deletedSizeResponse = _mapper.Map<DeletedSizeResponse>(deletedSize);
        return deletedSizeResponse;
    }

    public async Task<GetSizeResponse> GetByIdAsync(Guid id)
    {
        var size = await _sizeDal.GetAsync(predicate: c => c.Id == id);
        var mappedSize = _mapper.Map<GetSizeResponse>(size);
        return mappedSize;
    }

    public async Task<IPaginate<GetListSizeResponse>> GetListAsync(PageRequest pageRequest)
    {
        var sizes = await _sizeDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize);
        var mappedSizes = _mapper.Map<Paginate<GetListSizeResponse>>(sizes);
        return mappedSizes;
    }

    public async Task<UpdatedSizeResponse> UpdateAsync(UpdateSizeRequest updateSizeRequest)
    {
        await _sizeBusinessRules.IsExistsSize(updateSizeRequest.Id);

        Size size = _mapper.Map<Size>(updateSizeRequest);
        Size updatedSize = await _sizeDal.UpdateAsync(size);
        UpdatedSizeResponse updatedSizeResponse = _mapper.Map<UpdatedSizeResponse>(updatedSize);
        return updatedSizeResponse;
    }
}
