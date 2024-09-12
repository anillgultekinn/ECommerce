using AutoMapper;
using Business.Dtos.Requests.ColorRequests;
using Business.Dtos.Responses.ColorResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class ColorProfile : Profile
{
    public ColorProfile()
    {
        CreateMap<Color, CreateColorRequest>().ReverseMap();
        CreateMap<Color, UpdateColorRequest>().ReverseMap();

        CreateMap<Color, CreatedColorResponse>().ReverseMap();
        CreateMap<Color, UpdatedColorResponse>().ReverseMap();
        CreateMap<Color, DeletedColorResponse>().ReverseMap();

        CreateMap<IPaginate<Color>, Paginate<GetListColorResponse>>().ReverseMap();
        CreateMap<Color, GetListColorResponse>().ReverseMap();
        CreateMap<Color, GetColorResponse>().ReverseMap();
    }
}
