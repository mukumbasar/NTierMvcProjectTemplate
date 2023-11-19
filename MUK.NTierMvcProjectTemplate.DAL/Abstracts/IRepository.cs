using MUK.NTierMvcProjectTemplate.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MUK.NTierMvcProjectTemplate.DAL.Abstract
{
	public interface IRepository<T> where T : IEntity
	{
		void Add(T entity);
		void Delete(T entity);
		void Update(T entity);
		IQueryable<T> GetQueryable();
		List<T> GetAll(bool asnoTracking = true);
		List<T> GetAll(Expression<Func<T, bool>> filter);
		T? Get(Expression<Func<T, bool>> filter);
		T? Get(object id);
	}
}
