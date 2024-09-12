using AutoMapper;
using Business.Dtos.Requests.ProductRequests;
using Business.Dtos.Responses.ProductResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, CreateProductRequest>().ReverseMap();
        CreateMap<Product, UpdateProductRequest>().ReverseMap();

        CreateMap<Product, CreatedProductResponse>().ReverseMap();
        CreateMap<Product, UpdatedProductResponse>().ReverseMap();
        CreateMap<Product, DeletedProductResponse>().ReverseMap();

        CreateMap<IPaginate<Product>, Paginate<GetListProductResponse>>().ReverseMap();
        CreateMap<Product, GetListProductResponse>().ReverseMap();
        CreateMap<Product, GetProductResponse>().ReverseMap();
    }
}
