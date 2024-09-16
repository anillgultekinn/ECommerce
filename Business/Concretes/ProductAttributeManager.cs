using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.ProductAttributeRequests;
using Business.Dtos.Responses.ProductAttributeResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class ProductAttributeManager : IProductAttributeService
{
    IProductAttributeDal _productAttributeDal;
    IMapper _mapper;
    ProductAttributeBusinessRules _productAttributeBusinessRules;

    public ProductAttributeManager(IProductAttributeDal productAttributeDal, IMapper mapper, ProductAttributeBusinessRules productAttributeBusinessRules)
    {
        _productAttributeDal = productAttributeDal;
        _mapper = mapper;
        _productAttributeBusinessRules = productAttributeBusinessRules;
    }

    public async Task<CreatedProductAttributeResponse> AddAsync(CreateProductAttributeRequest createProductAttributeRequest)
    {
        ProductAttribute productAttribute = _mapper.Map<ProductAttribute>(createProductAttributeRequest);
        ProductAttribute createdProductAttribute = await _productAttributeDal.AddAsync(productAttribute);
        CreatedProductAttributeResponse createdProductAttributeResponse = _mapper.Map<CreatedProductAttributeResponse>(createdProductAttribute);
        return createdProductAttributeResponse;
    }

    public async Task<DeletedProductAttributeResponse> DeleteAsync(Guid id)
    {
        await _productAttributeBusinessRules.IExistProductAttribute(id);

        ProductAttribute productAttribute = await _productAttributeDal.GetAsync(predicate: p => p.Id == id);
        ProductAttribute deletedProductAttribute = await _productAttributeDal.DeleteAsync(productAttribute);
        DeletedProductAttributeResponse deletedProductAttributeResponse = _mapper.Map<DeletedProductAttributeResponse>(deletedProductAttribute);
        return deletedProductAttributeResponse;
    }

    public async Task<GetProductAttributeResponse> GetByIdAsync(Guid id)
    {
        var productAttribute = await _productAttributeDal.GetAsync(predicate: p => p.Id == id);
        var mappedProductAttribute = _mapper.Map<GetProductAttributeResponse>(productAttribute);
        return mappedProductAttribute;
    }

    public async Task<IPaginate<GetListProductAttributeResponse>> GetListAsync(PageRequest pageRequest)
    {
        var productAttributes = await _productAttributeDal.GetListAsync(
         index: pageRequest.PageIndex,
         size: pageRequest.PageSize);
        var mappedProductAttributes = _mapper.Map<Paginate<GetListProductAttributeResponse>>(productAttributes);
        return mappedProductAttributes;
    }

    public async Task<UpdatedProductAttributeResponse> UpdateAsync(UpdateProductAttributeRequest updateProductAttributeRequest)
    {
        await _productAttributeBusinessRules.IExistProductAttribute(updateProductAttributeRequest.Id);

        ProductAttribute productAttribute = _mapper.Map<ProductAttribute>(updateProductAttributeRequest);
        ProductAttribute updatedProductAttribute = await _productAttributeDal.UpdateAsync(productAttribute);
        UpdatedProductAttributeResponse updatedProductAttributeResponse = _mapper.Map<UpdatedProductAttributeResponse>(updatedProductAttribute);
        return updatedProductAttributeResponse;
    }
}
