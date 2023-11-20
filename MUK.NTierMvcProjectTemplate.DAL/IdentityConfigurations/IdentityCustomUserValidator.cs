using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MUK.NTierMvcProjectTemplate.DAL.Contexts;
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
		private readonly AppDbContext _context;

        public IdentityCustomUserValidator(AppDbContext context)
        {
            _context = context;
        }

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

            if (_context.Users.Where(u => u.Email == user.Email).Any())
            {
                errors.Add(new IdentityError() { Code = "", Description = "Başka bir email giriniz." });
            }

            if (errors.Any())
			{
				return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
			}

			return Task.FromResult(IdentityResult.Success);
		}
	}
}
