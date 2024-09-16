using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.ProductRequests;
using Business.Dtos.Responses.ProductResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class ProductManager : IProductService
{
    IProductDal _productDal;
    IMapper _mapper;
    ProductBusinessRules _productBusinessRules;

    public ProductManager(IProductDal productDal, IMapper mapper, ProductBusinessRules productBusinessRules)
    {
        _productDal = productDal;
        _mapper = mapper;
        _productBusinessRules = productBusinessRules;
    }


    public async Task<CreatedProductResponse> AddAsync(CreateProductRequest createProductRequest)
    {
        Product product = _mapper.Map<Product>(createProductRequest);
        Product createdProduct = await _productDal.AddAsync(product);
        CreatedProductResponse createdProductResponse = _mapper.Map<CreatedProductResponse>(createdProduct);
        return createdProductResponse;
    }

    public async Task<DeletedProductResponse> DeleteAsync(Guid id)
    {
        await _productBusinessRules.IExistProduct(id);

        Product product = await _productDal.GetAsync(predicate: p => p.Id == id);
        Product deletedProduct = await _productDal.DeleteAsync(product);
        DeletedProductResponse deletedProductResponse = _mapper.Map<DeletedProductResponse>(deletedProduct);
        return deletedProductResponse;
    }

    public async Task<GetProductResponse> GetByIdAsync(Guid id)
    {
        var product = await _productDal.GetAsync(
             include: p => p
             .Include(p => p.Category)
             .Include(p => p.Brand),
            predicate: p => p.Id == id
            );
        var mappedProduct = _mapper.Map<GetProductResponse>(product);
        return mappedProduct;
    }

    public async Task<IPaginate<GetListProductResponse>> GetListAsync(PageRequest pageRequest)
    {
        var products = await _productDal.GetListAsync(
             include: p => p
             .Include(p => p.Category)
             .Include(p => p.Brand),
         index: pageRequest.PageIndex,
         size: pageRequest.PageSize

         );
        var mappedProducts = _mapper.Map<Paginate<GetListProductResponse>>(products);
        return mappedProducts;
    }

    public async Task<UpdatedProductResponse> UpdateAsync(UpdateProductRequest updateProductRequest)
    {
        await _productBusinessRules.IExistProduct(updateProductRequest.Id);


        Product product = _mapper.Map<Product>(updateProductRequest);
        Product updatedProduct = await _productDal.UpdateAsync(product);
        UpdatedProductResponse updatedProductResponse = _mapper.Map<UpdatedProductResponse>(updatedProduct);
        return updatedProductResponse;
    }
}
