using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MUK.NTierMvcProjectTemplate.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUK.NTierMvcProjectTemplate.DAL.Contexts
{
	public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
	{
        public AppDbContext(DbContextOptions<AppDbContext> option): base(option)
        {
            
        }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}
	}
}
