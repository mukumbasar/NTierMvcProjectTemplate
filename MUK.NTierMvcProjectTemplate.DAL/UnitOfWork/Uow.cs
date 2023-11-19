using MUK.NTierMvcProjectTemplate.DAL.Abstract;
using MUK.NTierMvcProjectTemplate.DAL.Contexts;
using MUK.NTierMvcProjectTemplate.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUK.NTierMvcProjectTemplate.DAL.UnitOfWork
{
	public class Uow : IUow
	{
		private readonly AppDbContext _context;

		public Uow(AppDbContext context)
		{
			_context = context;
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		IRepository<T> IUow.GetRepository<T>()
		{
			return new GenericRepository<T>(_context);
		}
	}
}
