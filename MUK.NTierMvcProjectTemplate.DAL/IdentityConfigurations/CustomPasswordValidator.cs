using Microsoft.AspNetCore.Identity;
using MUK.NTierMvcProjectTemplate.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUK.NTierMvcProjectTemplate.DAL.IdentityConfigurations
{
	public class CustomPasswordValidator : IPasswordValidator<AppUser>
	{
		public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string? password)
		{
			var errors = new List<IdentityError>();
			if (password!.ToLower().Contains(user.UserName!))
			{
				errors.Add(new() { Code = "2", Description = "şifre kullanıcı adı içeremez" });
			}
			if (password!.ToLower().Contains("12345"))
			{

				errors.Add(new() { Code = "Password", Description = "şifre 12345 içeremez." });
			}

			if (errors.Any())
			{
				return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
			}
			return Task.FromResult(IdentityResult.Success);
		}
	}
}
