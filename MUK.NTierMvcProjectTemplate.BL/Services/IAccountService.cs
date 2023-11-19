using MUK.NTierMvcProjectTemplate.Dtos.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUK.NTierMvcProjectTemplate.BL.Services
{
	public interface IAccountService
	{
		ValueTask<(bool, List<string>)> RegisterAsync(CreateAppUserDto dto);
		ValueTask<(bool, string)> LogInAsync(LogInAppUserDto dto);
		ValueTask<string> ActivateEmailAsync(string userId, string token);

        void SignOutAsync();

    }
}
