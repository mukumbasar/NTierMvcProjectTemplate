using MUK.NTierMvcProjectTemplate.Dtos.Concrete;
using MUK.NTierMvcProjectTemplate.BL.RequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUK.NTierMvcProjectTemplate.BL.Services
{
    public interface IAccountService
	{
		Task<Response> RegisterAsync(CreateAppUserDto dto);
		Task<Response> LogInAsync(LogInAppUserDto dto);
		Task<Response> ActivateEmailAsync(string userId, string token);
        void SignOutAsync();
    }
}
