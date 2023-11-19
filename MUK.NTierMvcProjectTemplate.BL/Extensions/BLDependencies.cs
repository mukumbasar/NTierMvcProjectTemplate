using Microsoft.Extensions.DependencyInjection;
using MUK.NTierMvcProjectTemplate.BL.Managers;
using MUK.NTierMvcProjectTemplate.BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MUK.NTierMvcProjectTemplate.BL.Extensions
{
	public static class BLDepedencies
	{
		public static void AddBLDepecenies(this IServiceCollection services)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());

			#region Custom Services
			services.AddScoped<IEmailService, EmailManager>();
			services.AddScoped<IAccountService, AccountManager>();
			#endregion
		}
	}
}
