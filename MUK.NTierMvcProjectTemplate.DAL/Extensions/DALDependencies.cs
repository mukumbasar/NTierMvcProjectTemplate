using Microsoft.Extensions.DependencyInjection;
using MUK.NTierMvcProjectTemplate.DAL.Abstract;
using MUK.NTierMvcProjectTemplate.DAL.Contexts;
using MUK.NTierMvcProjectTemplate.Entities.Concrete;
using MUK.NTierMvcProjectTemplate.DAL.IdentityConfigurations;
using MUK.NTierMvcProjectTemplate.DAL.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUK.NTierMvcProjectTemplate.DAL.Extensions
{
	public static class DALDependencies
	{
		public static void AddDALDependencies(this IServiceCollection services, string connectionString)
		{
			//dbcontext kayıt
			services.AddDbContext<AppDbContext>(x =>
			{
				x.UseSqlServer(connectionString);
			});

			#region Identity Container Configuration
			services.AddIdentity<AppUser, AppRole>(option =>
			{
				option.User.AllowedUserNameCharacters =
				"abcçdefgğhiıjklmnoöprsştuüvyz" +
				"ABCÇDEFGĞHİIJKLMNOÖPRSŞTUÜVYZ" +
				"QWX" + "wqx" + "1234567890";

				option.User.RequireUniqueEmail = true;
				option.SignIn.RequireConfirmedEmail = false;//ileri true
				option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
				option.Lockout.MaxFailedAccessAttempts = 6;

				option.Password.RequiredLength = 8;
				option.Password.RequireNonAlphanumeric = false;
				option.Password.RequireLowercase = false;
				option.Password.RequireUppercase = false;
				option.Password.RequireDigit = true;

			}).AddUserValidator<IdentityCustomUserValidator>()
				.AddPasswordValidator<CustomPasswordValidator>()
				.AddDefaultTokenProviders()
				.AddEntityFrameworkStores<AppDbContext>();


			services.Configure<SecurityStampValidatorOptions>(option =>
			{
				option.ValidationInterval = TimeSpan.FromMinutes(100);
			});

			services.Configure<DataProtectionTokenProviderOptions>(option =>
			{
				option.TokenLifespan = TimeSpan.FromHours(5);
			});

			#endregion

			#region Uow and Repos
			services.AddScoped<IUow, Uow>();
			#endregion
		}
	}
}
