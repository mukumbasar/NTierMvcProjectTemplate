using Microsoft.AspNetCore.Identity;
using MUK.NTierMvcProjectTemplate.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUK.NTierMvcProjectTemplate.DAL.IdentityConfigurations
{
	public class IdentityCustomUserValidator : IUserValidator<AppUser>
	{
		public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
		{
			var errors = new List<IdentityError>();
			if (user.UserName.Contains("Salak"))
			{
				errors.Add(new IdentityError() { Code = "", Description = "kulllanıcı adı salak kelimesin içeremez!" });
			}

			if (char.IsDigit(user.UserName[0]))
			{
				errors.Add(new IdentityError() { Code = "", Description = "kulllanıcı adının ilk karakteri sayıyal bir değer olmaz" });
			}

			if (errors.Any())
			{
				return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
			}

			return Task.FromResult(IdentityResult.Success);
		}
	}
}
