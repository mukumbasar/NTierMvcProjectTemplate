﻿using AutoMapper;
using MUK.NTierMvcProjectTemplate.BL.Services;
using MUK.NTierMvcProjectTemplate.DAL.Abstract;
using MUK.NTierMvcProjectTemplate.Dtos.Concrete;
using MUK.NTierMvcProjectTemplate.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUK.NTierMvcProjectTemplate.BL.Managers
{
    public class ThingManager : BaseManager<Thing, ThingDto>, IThingService
    {
        public ThingManager(IMapper mapper, IUow uow) : base(mapper, uow)
        {

        }
    }
}
