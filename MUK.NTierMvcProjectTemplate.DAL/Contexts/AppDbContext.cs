using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MUK.NTierMvcProjectTemplate.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MUK.NTierMvcProjectTemplate.DAL.Contexts
{
	public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
	{
        public DbSet<Konu> Konular { get; set; }
        public DbSet<Makale> Makaleler { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> option): base(option)
        {
            
        }

		protected override void OnModelCreating(ModelBuilder builder)
		{
            builder.Entity<Konu>().HasData(
                new { Id = 1, Ad = "Bilim" },
                new { Id = 2, Ad = "Spor" },
                new { Id = 3, Ad = "Siyaset" }
                );

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
		}
	}
}
