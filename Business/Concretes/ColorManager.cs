using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.ColorRequests;
using Business.Dtos.Responses.ColorResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class ColorManager : IColorService
{
    IColorDal _colorDal;
    IMapper _mapper;
    ColorBusinessRules _colorBusinessRules;


    public ColorManager(IColorDal colorDal, IMapper mapper, ColorBusinessRules colorBusinessRules)
    {
        _colorDal = colorDal;
        _mapper = mapper;
        _colorBusinessRules = colorBusinessRules;
    }

    public async Task<CreatedColorResponse> AddAsync(CreateColorRequest createColorRequest)
    {
        Color color = _mapper.Map<Color>(createColorRequest);
        Color createdColor = await _colorDal.AddAsync(color);
        CreatedColorResponse createdColorResponse = _mapper.Map<CreatedColorResponse>(createdColor);
        return createdColorResponse;
    }

    public async Task<DeletedColorResponse> DeleteAsync(Guid id)
    {
        await _colorBusinessRules.IsExistsColor(id);
        Color color = await _colorDal.GetAsync(predicate: c => c.Id == id);
        Color deletedColor = await _colorDal.DeleteAsync(color);
        DeletedColorResponse deletedColorResponse = _mapper.Map<DeletedColorResponse>(deletedColor);
        return deletedColorResponse;
    }

    public async Task<GetColorResponse> GetByIdAsync(Guid id)
    {
        var color = await _colorDal.GetAsync(predicate: c => c.Id == id);
        var mappedColor = _mapper.Map<GetColorResponse>(color);
        return mappedColor;
    }

    public async Task<IPaginate<GetListColorResponse>> GetListAsync(PageRequest pageRequest)
    {

        var colors = await _colorDal.GetListAsync(
           index: pageRequest.PageIndex,
           size: pageRequest.PageSize);
        var mappedColors = _mapper.Map<Paginate<GetListColorResponse>>(colors);
        return mappedColors;
    }

    public async Task<UpdatedColorResponse> UpdateAsync(UpdateColorRequest updateColorRequest)
    {
        await _colorBusinessRules.IsExistsColor(updateColorRequest.Id);

        Color color = _mapper.Map<Color>(updateColorRequest);
        Color updatedColor = await _colorDal.UpdateAsync(color);
        UpdatedColorResponse updatedColorResponse = _mapper.Map<UpdatedColorResponse>(updatedColor);
        return updatedColorResponse;
    }
}
