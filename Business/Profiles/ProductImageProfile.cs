using AutoMapper;
using Business.Dtos.Requests.ProductImageRequests;
using Business.Dtos.Responses.ProductImageResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class ProductImageProfile : Profile
{
    public ProductImageProfile()
    {
        CreateMap<ProductImage, CreateProductImageRequest>().ReverseMap();
        CreateMap<ProductImage, UpdateProductImageRequest>().ReverseMap();

        CreateMap<ProductImage, CreatedProductImageResponse>().ReverseMap();
        CreateMap<ProductImage, UpdatedProductImageResponse>().ReverseMap();
        CreateMap<ProductImage, DeletedProductImageResponse>().ReverseMap();

        CreateMap<IPaginate<ProductImage>, Paginate<GetListProductImageResponse>>().ReverseMap();
        CreateMap<ProductImage, GetListProductImageResponse>().ReverseMap();
        CreateMap<ProductImage, GetProductImageResponse>().ReverseMap();
    }
}
