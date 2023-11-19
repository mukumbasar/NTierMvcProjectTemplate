using MUK.NTierMvcProjectTemplate.Dtos.Base;
using MUK.NTierMvcProjectTemplate.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUK.NTierMvcProjectTemplate.BL.Base
{
	public interface IService<CreateDto, UpdateDto, ListDto, T>
		where T : class, IEntity
		where CreateDto : class, ICreateDto
		where UpdateDto : class, IUpdateDto
		where ListDto : class, IListDto
	{
		void Add(CreateDto dto);
		void Update(UpdateDto dto);
		void Delete(object id);
		T Get(object id);
		List<ListDto> GetAll();
	}
}
