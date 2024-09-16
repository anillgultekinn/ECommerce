using AutoMapper;
using Business.Dtos.Requests.ProductAttributeRequests;
using Business.Dtos.Responses.ProductAttributeResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class ProductAttributeProfile : Profile
{
    public ProductAttributeProfile()
    {
        CreateMap<ProductAttribute, CreateProductAttributeRequest>().ReverseMap();
        CreateMap<ProductAttribute, UpdateProductAttributeRequest>().ReverseMap();

        CreateMap<ProductAttribute, CreatedProductAttributeResponse>().ReverseMap();
        CreateMap<ProductAttribute, UpdatedProductAttributeResponse>().ReverseMap();
        CreateMap<ProductAttribute, DeletedProductAttributeResponse>().ReverseMap();

        CreateMap<IPaginate<ProductAttribute>, Paginate<GetListProductAttributeResponse>>().ReverseMap();
        CreateMap<ProductAttribute, GetListProductAttributeResponse>().ReverseMap();
        CreateMap<ProductAttribute, GetProductAttributeResponse>().ReverseMap();
    }
}
