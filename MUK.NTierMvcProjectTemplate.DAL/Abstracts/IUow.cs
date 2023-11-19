using MUK.NTierMvcProjectTemplate.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUK.NTierMvcProjectTemplate.DAL.Abstract
{
	public interface IUow
	{
		void SaveChanges();
		IRepository<T> GetRepository<T>() where T : class, IEntity;
	}
}
