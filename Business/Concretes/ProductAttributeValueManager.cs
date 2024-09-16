using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.ProductAttributeValueRequests;
using Business.Dtos.Responses.ProductAttributeValueResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class ProductAttributeValueManager : IProductAttributeValueService
{
    IProductAttributeValueDal _productAttributeValueDal;
    IMapper _mapper;
    ProductAttributeValueBusinessRules _productAttributeValueBusinessRules;

    public ProductAttributeValueManager(IProductAttributeValueDal productAttributeValueDal, IMapper mapper, ProductAttributeValueBusinessRules productAttributeValueBusinessRules)
    {
        _productAttributeValueDal = productAttributeValueDal;
        _mapper = mapper;
        _productAttributeValueBusinessRules = productAttributeValueBusinessRules;
    }

    public async Task<CreatedProductAttributeValueResponse> AddAsync(CreateProductAttributeValueRequest createProductAttributeValueRequest)
    {
        ProductAttributeValue productAttributeValue = _mapper.Map<ProductAttributeValue>(createProductAttributeValueRequest);
        ProductAttributeValue createdProductAttributeValue = await _productAttributeValueDal.AddAsync(productAttributeValue);
        CreatedProductAttributeValueResponse createdProductAttributeValueResponse = _mapper.Map<CreatedProductAttributeValueResponse>(createdProductAttributeValue);
        return createdProductAttributeValueResponse;
    }
    public async Task<DeletedProductAttributeValueResponse> DeleteAsync(Guid id)
    {
        await _productAttributeValueBusinessRules.IExistProductAttributeValue(id);

        ProductAttributeValue productAttributeValue = await _productAttributeValueDal.GetAsync(predicate: p => p.Id == id);
        ProductAttributeValue deletedProductAttributeValue = await _productAttributeValueDal.DeleteAsync(productAttributeValue);
        DeletedProductAttributeValueResponse deletedProductAttributeValueResponse = _mapper.Map<DeletedProductAttributeValueResponse>(deletedProductAttributeValue);
        return deletedProductAttributeValueResponse;
    }

    public async Task<GetProductAttributeValueResponse> GetByIdAsync(Guid id)
    {
        var productAttributeValue = await _productAttributeValueDal.GetAsync(predicate: pa => pa.Id == id);
        var mappedProductAttributeValue = _mapper.Map<GetProductAttributeValueResponse>(productAttributeValue);
        return mappedProductAttributeValue;
    }

    public async Task<IPaginate<GetListProductAttributeValueResponse>> GetListAsync(PageRequest pageRequest)
    {
        var productAttributeValues = await _productAttributeValueDal.GetListAsync(
            include: p => p
            .Include(p => p.ProductAttribute),
         index: pageRequest.PageIndex,
         size: pageRequest.PageSize);
        var mappedProductAttributeValues = _mapper.Map<Paginate<GetListProductAttributeValueResponse>>(productAttributeValues);
        return mappedProductAttributeValues;
    }

    public async Task<UpdatedProductAttributeValueResponse> UpdateAsync(UpdateProductAttributeValueRequest updateProductAttributeValueRequest)
    {
        await _productAttributeValueBusinessRules.IExistProductAttributeValue(updateProductAttributeValueRequest.Id);

        ProductAttributeValue productAttributeValue = _mapper.Map<ProductAttributeValue>(updateProductAttributeValueRequest);
        ProductAttributeValue updatedProductAttributeValue = await _productAttributeValueDal.UpdateAsync(productAttributeValue);
        UpdatedProductAttributeValueResponse updatedProductAttributeValueResponse = _mapper.Map<UpdatedProductAttributeValueResponse>(updatedProductAttributeValue);
        return updatedProductAttributeValueResponse;
    }
}
