using AutoMapper;
using MUK.NTierMvcProjectTemplate.Dtos.AppUserDtos;
using MUK.NTierMvcProjectTemplate.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUK.NTierMvcProjectTemplate.BL.Mappings
{
    public class BLModelProfile : Profile
    {
        public BLModelProfile()
        {
            CreateMap<AppUser, CreateAppUserDto>().ReverseMap();
        }
    }
}
