using AutoMapper;
using Business.Dtos.Requests.BrandRequests;
using Business.Dtos.Responses.BrandResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class BrandProfile : Profile
{
    public BrandProfile()
    {
        CreateMap<Brand, CreateBrandRequest>().ReverseMap();
        CreateMap<Brand, UpdateBrandRequest>().ReverseMap();

        CreateMap<Brand, CreatedBrandResponse>().ReverseMap();
        CreateMap<Brand, UpdatedBrandResponse>().ReverseMap();
        CreateMap<Brand, DeletedBrandResponse>().ReverseMap();

        CreateMap<IPaginate<Brand>, Paginate<GetListBrandResponse>>().ReverseMap();
        CreateMap<Brand, GetListBrandResponse>().ReverseMap();
        CreateMap<Brand, GetBrandResponse>().ReverseMap();
    }
}
