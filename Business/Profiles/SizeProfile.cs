using AutoMapper;
using Business.Dtos.Requests.SizeRequests;
using Business.Dtos.Responses.SizeResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class SizeProfile : Profile
{
    public SizeProfile()
    {
        CreateMap<Size, CreateSizeRequest>().ReverseMap();
        CreateMap<Size, UpdateSizeRequest>().ReverseMap();

        CreateMap<Size, CreatedSizeResponse>().ReverseMap();
        CreateMap<Size, UpdatedSizeResponse>().ReverseMap();
        CreateMap<Size, DeletedSizeResponse>().ReverseMap();

        CreateMap<IPaginate<Size>, Paginate<GetListSizeResponse>>().ReverseMap();
        CreateMap<Size, GetListSizeResponse>().ReverseMap();
        CreateMap<Size, GetSizeResponse>().ReverseMap();

    }
}
