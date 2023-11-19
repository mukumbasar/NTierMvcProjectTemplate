using AutoMapper;
using MUK.NTierMvcProjectTemplate.Dtos;
using MUK.NTierMvcProjectTemplate.Dtos.AppUserDtos;
using MUK.NTierMvcProjectTemplate.Web.Models;

namespace MUK.NTierMvcProjectTemplate.Web.Mappings
{
    public class WebModelProfile : Profile
    {
        public WebModelProfile()
        {
            CreateMap<RegisterViewModel, CreateAppUserDto>().ReverseMap();
            CreateMap<LogInViewModel, LogInAppUserDto>().ReverseMap();
        }
    }
}
