using Microsoft.EntityFrameworkCore;
using MUK.NTierMvcProjectTemplate.DAL.Abstract;
using MUK.NTierMvcProjectTemplate.DAL.Contexts;
using MUK.NTierMvcProjectTemplate.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUK.NTierMvcProjectTemplate.DAL.Repository
{
	public class GenericRepository<T>
		: IRepository<T>
		where T : class, IEntity
	{

		private readonly AppDbContext _context;

		public GenericRepository(AppDbContext context)
		{
			_context = context;
		}

		public void Add(T entity)
		{
			_context.Set<T>().Add(entity);
		}

		public void Delete(T entity)
		{
			_context.Set<T>().Remove(entity);
		}

		public T? Get(System.Linq.Expressions.Expression<Func<T, bool>> filter)
		{
			return _context.Set<T>().Where(filter).FirstOrDefault();
		}

		public T? Get(object id)
		{
			return _context.Set<T>().Find(id);
		}

		public List<T> GetAll(bool asnoTracking = true)
		{
			return asnoTracking ?
					 _context.Set<T>().ToList() :
					 _context.Set<T>().AsNoTracking().ToList();
		}

		public List<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> filter)
		{
			return _context.Set<T>().Where(filter).ToList();
		}

		public IQueryable<T> GetQueryable()
		{
			return _context.Set<T>().AsQueryable<T>();
		}

		public void Update(T entity)
		{
			_context.Update(entity);
		}
	}
}
