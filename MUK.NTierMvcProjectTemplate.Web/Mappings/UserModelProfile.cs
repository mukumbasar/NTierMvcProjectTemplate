using AutoMapper;
using MUK.NTierMvcProjectTemplate.Dtos;
using MUK.NTierMvcProjectTemplate.Dtos.AppUserDtos;
using MUK.NTierMvcProjectTemplate.Web.Models;

namespace MUK.NTierMvcProjectTemplate.Web.Mappings
{
    public class UserModelProfile : Profile
    {
        public UserModelProfile()
        {
            CreateMap<RegisterViewModel, CreateAppUserDto>().ReverseMap();
            CreateMap<LogInViewModel, LogInAppUserDto>().ReverseMap();
        }
    }
}
