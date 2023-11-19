using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using MUK.NTierMvcProjectTemplate.BL.Services;
using MUK.NTierMvcProjectTemplate.Dtos.AppUserDtos;
using MUK.NTierMvcProjectTemplate.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUK.NTierMvcProjectTemplate.BL.Managers
{
	public class AccountManager : IAccountService
	{

		private readonly SignInManager<AppUser> _signInManager;
		private readonly UserManager<AppUser> _userManager;
		private readonly IMapper _mapper;
		private readonly IEmailService _mailService;

		public AccountManager(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IMapper mapper, IEmailService mailService)
		{
			_signInManager = signInManager;
			_userManager = userManager;
			_mapper = mapper;
			_mailService = mailService;
		}

		public async ValueTask<(bool, List<string>)> RegisterAsync(CreateAppUserDto dto)
		{
			var user = _mapper.Map<AppUser>(dto);

			var result = await _userManager.CreateAsync(user, dto.Password);

			if (result.Succeeded)
			{
				var registredUser = await _userManager.FindByEmailAsync(dto.Email);

				var token = await _userManager.GenerateEmailConfirmationTokenAsync(registredUser);
				var userID = registredUser.Id;

                byte[] tokenGeneratedBytes = Encoding.UTF8.GetBytes(token);
                var codeEncoded = WebEncoders.Base64UrlEncode(tokenGeneratedBytes);

                var url = EmailComfirmLinkGenerator(registredUser.Id, codeEncoded);

				var html = $@"<html><head></head>
                        <body>
                                    <h2>HOŞGELDİN</h2>
                            <a href = {url}> Hesap Aktivasyon Buraya Tıklayınız </a>
                        </body>
                       </html>";

				_mailService.SendMail(user.Email, "Email Confirm", html);

				return (true, new List<string>());
			}

			var errorList = result.Errors.Select(x =>
			 x.Description
			 ).ToList();

			return (false, errorList);
		}
		public async ValueTask<string> ActivateEmailAsync(string userId, string token)
		{
            var codeDecodedBytes = WebEncoders.Base64UrlDecode(token);
            var codeDecoded = Encoding.UTF8.GetString(codeDecodedBytes);

            var user = await _userManager.FindByIdAsync(userId);

            var result = await _userManager.ConfirmEmailAsync(user, codeDecoded);

            if (result.Succeeded)
            {
				return "Aktivasyon başarılı.";
            }
			return "Aktivasyon başarısız.";
        }
		public async ValueTask<(bool, string)> LogInAsync(LogInAppUserDto dto)
		{
			try
			{
				var user = await _userManager.FindByEmailAsync(dto.Email);

				await _signInManager.SignOutAsync();

				var result = await _signInManager.PasswordSignInAsync(user, dto.Password, false, true);

				if (result.Succeeded)
				{
					await _userManager.ResetAccessFailedCountAsync(user);
					await _userManager.SetLockoutEndDateAsync(user, null);

					return (true, "Giriş başarılı.");
				}

				if(result.IsLockedOut)
				{
                    var lockoutEndUtc = await _userManager.GetLockoutEndDateAsync(user);
                    var timeLeft = lockoutEndUtc.Value - DateTime.UtcNow;

                    return (false, $"Giriş başarısız. Lütfen {timeLeft.Minutes} dakika sonra tekrar deneyiniz.");
                }

				return (false, "Giriş başarısız.");
			}
			catch
			{
				return (false, "Email ya da parola yanlış girildi.");
			}
		}
		public async void SignOutAsync()
		{
			await _signInManager.SignOutAsync();
		}
        private string EmailComfirmLinkGenerator(string userId, string token)
		{
			var link = "https://localhost:7293/Account/EmailActivation";

			link += "?" + "userId=" + userId + "&token=" + token;

			return link;
		}
	}
}
