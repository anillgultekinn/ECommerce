using AutoMapper;
using Business.Dtos.Requests.ProductDetailRequests;
using Business.Dtos.Responses.ProductDetailResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class ProductDetailProfile : Profile
{
    public ProductDetailProfile()
    {
        CreateMap<ProductDetail, CreateProductDetailRequest>().ReverseMap();
        CreateMap<ProductDetail, UpdateProductDetailRequest>().ReverseMap();

        CreateMap<ProductDetail, CreatedProductDetailResponse>().ReverseMap();
        CreateMap<ProductDetail, UpdatedProductDetailResponse>().ReverseMap();
        CreateMap<ProductDetail, DeletedProductDetailResponse>().ReverseMap();

        CreateMap<IPaginate<ProductDetail>, Paginate<GetListProductDetailResponse>>().ReverseMap();

        CreateMap<ProductDetail, GetListProductDetailResponse>()
            .ForMember(destinationMember: response => response.ProductTitle,
             memberOptions: opt => opt.MapFrom(p => p.Product.Title)).ReverseMap();

        CreateMap<ProductDetail, GetProductDetailResponse>().ReverseMap();
    }
}
