using AutoMapper;
using Business.Dtos.Requests.ProductAttributeValueRequests;
using Business.Dtos.Responses.ProductAttributeValueResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class ProductAttributeValueProfile : Profile
{
    public ProductAttributeValueProfile()
    {
        CreateMap<ProductAttributeValue, CreateProductAttributeValueRequest>().ReverseMap();
        CreateMap<ProductAttributeValue, UpdateProductAttributeValueRequest>().ReverseMap();

        CreateMap<ProductAttributeValue, CreatedProductAttributeValueResponse>().ReverseMap();
        CreateMap<ProductAttributeValue, UpdatedProductAttributeValueResponse>().ReverseMap();
        CreateMap<ProductAttributeValue, DeletedProductAttributeValueResponse>().ReverseMap();

        CreateMap<IPaginate<ProductAttributeValue>, Paginate<GetListProductAttributeValueResponse>>().ReverseMap();
        CreateMap<ProductAttributeValue, GetListProductAttributeValueResponse>().ReverseMap();
        CreateMap<ProductAttributeValue, GetProductAttributeValueResponse>().ReverseMap();
    }
}
