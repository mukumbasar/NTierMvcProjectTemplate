using MUK.NTierMvcProjectTemplate.BL.RequestResponse;
using MUK.NTierMvcProjectTemplate.Dtos.Base;
using MUK.NTierMvcProjectTemplate.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MUK.NTierMvcProjectTemplate.BL.Services
{
    public interface IBaseService<T, TDto> where T : class, IEntity where TDto : class, IDto
    {
        Response Insert(TDto dto);
        Response Update(TDto dto);
        Response Delete(TDto dto);
        Response<TDto> Get(int id);
        Response<IEnumerable<TDto>> GetAll();
    }
}
