using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.ProductDetailRequests;
using Business.Dtos.Responses.ProductDetailResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class ProductDetailManager : IProductDetailService
{
    IProductDetailDal _productDetailDal;
    IMapper _mapper;
    ProductDetailBusinessRules _productDetailBusinessRules;

    public ProductDetailManager(IProductDetailDal productDetailDal, IMapper mapper, ProductDetailBusinessRules productDetailBusinessRules)
    {
        _productDetailDal = productDetailDal;
        _mapper = mapper;
        _productDetailBusinessRules = productDetailBusinessRules;
    }

    public async Task<CreatedProductDetailResponse> AddAsync(CreateProductDetailRequest createProductDetailRequest)
    {
        ProductDetail productDetail = _mapper.Map<ProductDetail>(createProductDetailRequest);
        ProductDetail createdProductDetail = await _productDetailDal.AddAsync(productDetail);
        CreatedProductDetailResponse createdProductDetailResponse = _mapper.Map<CreatedProductDetailResponse>(createdProductDetail);
        return createdProductDetailResponse;
    }

    public async Task<DeletedProductDetailResponse> DeleteAsync(Guid id)
    {
        await _productDetailBusinessRules.IExistProductDetail(id);

        ProductDetail productDetail = await _productDetailDal.GetAsync(predicate: p => p.Id == id);
        ProductDetail deletedProductDetail = await _productDetailDal.DeleteAsync(productDetail);
        DeletedProductDetailResponse deletedProductDetailResponse = _mapper.Map<DeletedProductDetailResponse>(deletedProductDetail);
        return deletedProductDetailResponse;
    }

    public async Task<GetProductDetailResponse> GetByIdAsync(Guid id)
    {
        var productDetail = await _productDetailDal.GetAsync(predicate: p => p.Id == id);
        var mappedProductDetail = _mapper.Map<GetProductDetailResponse>(productDetail);
        return mappedProductDetail;
    }

    public async Task<IPaginate<GetListProductDetailResponse>> GetListAsync(PageRequest pageRequest)
    {
        var productDetails = await _productDetailDal.GetListAsync(
         index: pageRequest.PageIndex,
         size: pageRequest.PageSize);
        var mappedProductDetails = _mapper.Map<Paginate<GetListProductDetailResponse>>(productDetails);
        return mappedProductDetails;
    }

    public async Task<UpdatedProductDetailResponse> UpdateAsync(UpdateProductDetailRequest updateProductDetailRequest)
    {
        await _productDetailBusinessRules.IExistProductDetail(updateProductDetailRequest.Id);

        ProductDetail productDetail = _mapper.Map<ProductDetail>(updateProductDetailRequest);
        ProductDetail updatedProductDetail = await _productDetailDal.UpdateAsync(productDetail);
        UpdatedProductDetailResponse updatedProductDetailResponse = _mapper.Map<UpdatedProductDetailResponse>(updatedProductDetail);
        return updatedProductDetailResponse;
    }
}
