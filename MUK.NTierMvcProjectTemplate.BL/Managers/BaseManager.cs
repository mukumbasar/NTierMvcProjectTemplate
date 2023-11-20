using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MUK.NTierMvcProjectTemplate.BL.RequestResponse;
using MUK.NTierMvcProjectTemplate.BL.Services;
using MUK.NTierMvcProjectTemplate.Entities.Abstract;
using MUK.NTierMvcProjectTemplate.Dtos.Base;
using AutoMapper;
using MUK.NTierMvcProjectTemplate.DAL.Abstract;
using MUK.NTierMvcProjectTemplate.DAL.UnitOfWork;

namespace MUK.NTierMvcProjectTemplate.BL.Managers
{
    public class BaseManager<T, TDto> : IBaseService<T, TDto> where T : class, IEntity where TDto : class, IDto
    {
        protected readonly IMapper _mapper;
        protected readonly IUow _uow;

        public BaseManager(IMapper mapper, IUow uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public Response Delete(TDto dto)
        {
            try
            {
                var entity = _mapper.Map<T>(dto);
                _uow.GetRepository<T>().Delete(entity);
                _uow.SaveChanges();
                return Response.Success("Deletion was successful.");
            }
            catch
            {
                return Response.Failure("Deletion was unsuccessful");
            }
        }

        public Response<TDto> Get(int id)
        {
            try
            {
                var entity = _uow.GetRepository<T>().Get(id);
                var dto = _mapper.Map<TDto>(entity);
                return Response<TDto>.Success(dto, "Acquirement was successful.");
            }
            catch
            {
                return Response<TDto>.Failure("Acquirement was unsuccessful");
            }
        }

        public Response<IEnumerable<TDto>> GetAll()
        {
            try
            {
                var entities = _uow.GetRepository<T>().GetAll();
                var dtos = _mapper.Map<List<TDto>>(entities);
                return Response<IEnumerable<TDto>>.Success(dtos, "Acquirement was successful.");
            }
            catch
            {
                return Response<IEnumerable<TDto>>.Failure("Acquirement was unsuccessful");
            }
        }

        public Response Insert(TDto dto)
        {
            try
            {
                var entity = _mapper.Map<T>(dto);
                _uow.GetRepository<T>().Add(entity);
                _uow.SaveChanges();
                return Response.Success("Insertion was successful.");
            }
            catch
            {
                return Response.Failure("Insertion was unsuccessful");
            }
        }

        public Response Update(TDto dto)
        {
            try
            {
                var entity = _mapper.Map<T>(dto);
                _uow.GetRepository<T>().Update(entity);
                _uow.SaveChanges();
                return Response.Success("Updating was successful.");
            }
            catch
            {
                return Response.Failure("Updating was unsuccessful");
            }
        }
    }
}
