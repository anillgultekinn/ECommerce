using AutoMapper;
using Azure;
using Business.Dtos.Requests.ProductRequests;
using Business.Dtos.Responses.ProductResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System.Diagnostics.Metrics;

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

        CreateMap<List<Product>, Paginate<GetListProductResponse>>()
          .ForMember(destinationMember: p => p.Items,
          memberOptions: opt => opt.MapFrom(p => p.ToList())).ReverseMap();


        CreateMap<Product, GetListProductResponse>()
             .ForMember(destinationMember: response => response.CategoryName,
             memberOptions: opt => opt.MapFrom(p => p.Category.Name))
             .ForMember(destinationMember: response => response.BrandName,
             memberOptions: opt => opt.MapFrom(p => p.Brand.Name)).ReverseMap();


        CreateMap<Product, GetProductResponse>().ForMember(destinationMember: response => response.CategoryName,
             memberOptions: opt => opt.MapFrom(p => p.Category.Name))
             .ForMember(destinationMember: response => response.BrandName,
             memberOptions: opt => opt.MapFrom(p => p.Brand.Name)).ReverseMap();

       
    }
}
