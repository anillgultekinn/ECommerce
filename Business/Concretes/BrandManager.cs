using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.AddressRequests;
using Business.Dtos.Requests.BrandRequests;
using Business.Dtos.Responses.BrandResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class BrandManager : IBrandService
{
    IBrandDal _brandDal;
    IMapper _mapper;
    BrandBusinessRules _brandBusinessRules;


    public BrandManager(IBrandDal brandDal, IMapper mapper, BrandBusinessRules brandBusinessRules)
    {
        _brandDal = brandDal;
        _mapper = mapper;
        _brandBusinessRules = brandBusinessRules;
    }


    public async Task<CreatedBrandResponse> AddAsync(CreateBrandRequest createBrandRequest)
    {
        Brand brand = _mapper.Map<Brand>(createBrandRequest);
        Brand createdBrand = await _brandDal.AddAsync(brand);
        CreatedBrandResponse createdBrandResponse = _mapper.Map<CreatedBrandResponse>(createdBrand);
        return createdBrandResponse;
    }

    public async Task<DeletedBrandResponse> DeleteAsync(Guid id)
    {
        await _brandBusinessRules.IsExistsBrand(id);
        Brand brand = await _brandDal.GetAsync(predicate: b => b.Id == id);
        Brand deletedBrand = await _brandDal.DeleteAsync(brand);
        DeletedBrandResponse deletedBrandResponse = _mapper.Map<DeletedBrandResponse>(deletedBrand);
        return deletedBrandResponse;
    }

    public async Task<GetBrandResponse> GetByIdAsync(Guid id)
    {
        var brand = await _brandDal.GetAsync(predicate: l => l.Id == id);
        var mappedBrand = _mapper.Map<GetBrandResponse>(brand);
        return mappedBrand;
    }

    public async Task<IPaginate<GetListBrandResponse>> GetListAsync(PageRequest pageRequest)
    {
        var brands = await _brandDal.GetListAsync(
           index: pageRequest.PageIndex,
           size: pageRequest.PageSize);
        var mappedBrands = _mapper.Map<Paginate<GetListBrandResponse>>(brands);
        return mappedBrands;
    }

    public async Task<UpdatedBrandResponse> UpdateAsync(UpdateBrandRequest updateBrandRequest)
    {
        await _brandBusinessRules.IsExistsBrand(updateBrandRequest.Id);

        Brand brand = _mapper.Map<Brand>(updateBrandRequest);
        Brand updatedBrand = await _brandDal.UpdateAsync(brand);
        UpdatedBrandResponse updatedBrandResponse = _mapper.Map<UpdatedBrandResponse>(updatedBrand);
        return updatedBrandResponse;
    }
}
