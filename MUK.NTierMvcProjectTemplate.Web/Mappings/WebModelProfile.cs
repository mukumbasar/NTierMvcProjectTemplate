using AutoMapper;
using MUK.NTierMvcProjectTemplate.Dtos;
using MUK.NTierMvcProjectTemplate.Dtos.Concrete;
using MUK.NTierMvcProjectTemplate.Entities.Concretes;
using MUK.NTierMvcProjectTemplate.Web.Models;

namespace MUK.NTierMvcProjectTemplate.Web.Mappings
{
    public class WebModelProfile : Profile
    {
        public WebModelProfile()
        {
            CreateMap<RegisterViewModel, CreateAppUserDto>().ReverseMap();
            CreateMap<LogInViewModel, LogInAppUserDto>().ReverseMap();
            CreateMap<MakaleViewModel, MakaleDto>().ReverseMap();
            CreateMap<KonuViewModel, KonuDto>().ReverseMap();
        }
    }
}
