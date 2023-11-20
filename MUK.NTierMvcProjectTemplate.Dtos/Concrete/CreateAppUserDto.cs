using MUK.NTierMvcProjectTemplate.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUK.NTierMvcProjectTemplate.Dtos.Concrete
{
	public class CreateAppUserDto : IDto
	{
		public string UserName { get; set; } = null!;
		public string Name { get; set; } = null!;
		public string Surname { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string Password { get; set; } = null!;
	}
}
