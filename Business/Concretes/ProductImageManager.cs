using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.ProductImageRequests;
using Business.Dtos.Responses.ProductImageResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class ProductImageManager : IProductImageService
{
    IProductImageDal _productImageDal;
    IMapper _mapper;
    ProductImageBusinessRules _productImageBusinessRules;

    public ProductImageManager(IProductImageDal productImageDal, IMapper mapper, ProductImageBusinessRules productImageBusinessRules)
    {
        _productImageDal = productImageDal;
        _mapper = mapper;
        _productImageBusinessRules = productImageBusinessRules;
    }
    public async Task<CreatedProductImageResponse> AddAsync(CreateProductImageRequest createProductImageRequest)
    {
        ProductImage productImage = _mapper.Map<ProductImage>(createProductImageRequest);
        ProductImage createdProductImage = await _productImageDal.AddAsync(productImage);
        CreatedProductImageResponse createdProductImageResponse = _mapper.Map<CreatedProductImageResponse>(createdProductImage);
        return createdProductImageResponse;
    }
    public async Task<DeletedProductImageResponse> DeleteAsync(Guid id)
    {
        await _productImageBusinessRules.IExistProductImage(id);

        ProductImage productImage = await _productImageDal.GetAsync(predicate: p => p.Id == id);
        ProductImage deletedProductImage = await _productImageDal.DeleteAsync(productImage);
        DeletedProductImageResponse deletedProductImageResponse = _mapper.Map<DeletedProductImageResponse>(deletedProductImage);
        return deletedProductImageResponse;
    }

    public async Task<GetProductImageResponse> GetByIdAsync(Guid id)
    {
        var productImage = await _productImageDal.GetAsync(predicate: p => p.Id == id);
        var mappedProductImage = _mapper.Map<GetProductImageResponse>(productImage);
        return mappedProductImage;
    }

    public async Task<IPaginate<GetListProductImageResponse>> GetListAsync(PageRequest pageRequest)
    {
        var productImages = await _productImageDal.GetListAsync(
         index: pageRequest.PageIndex,
         size: pageRequest.PageSize);
        var mappedProductImages = _mapper.Map<Paginate<GetListProductImageResponse>>(productImages);
        return mappedProductImages;
    }

    public async Task<UpdatedProductImageResponse> UpdateAsync(UpdateProductImageRequest updateProductImageRequest)
    {
        await _productImageBusinessRules.IExistProductImage(updateProductImageRequest.Id);

        ProductImage productImage = _mapper.Map<ProductImage>(updateProductImageRequest);
        ProductImage updatedProductImage = await _productImageDal.UpdateAsync(productImage);
        UpdatedProductImageResponse updatedProductImageResponse = _mapper.Map<UpdatedProductImageResponse>(updatedProductImage);
        return updatedProductImageResponse;
    }
}
