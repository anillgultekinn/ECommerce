using AutoMapper;
using Business.Dtos.Requests.GenderRequests;
using Business.Dtos.Responses.GenderResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class GenderProfile : Profile
{
    public GenderProfile()
    {
        CreateMap<Gender, CreateGenderRequest>().ReverseMap();
        CreateMap<Gender, UpdateGenderRequest>().ReverseMap();

        CreateMap<Gender, CreatedGenderResponse>().ReverseMap();
        CreateMap<Gender, UpdatedGenderResponse>().ReverseMap();
        CreateMap<Gender, DeletedGenderResponse>().ReverseMap();

        CreateMap<IPaginate<Gender>, Paginate<GetListGenderResponse>>().ReverseMap();
        CreateMap<Gender, GetListGenderResponse>().ReverseMap();
        CreateMap<Gender, GetGenderResponse>().ReverseMap();
    }
}
