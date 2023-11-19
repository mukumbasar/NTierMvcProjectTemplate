using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUK.NTierMvcProjectTemplate.Dtos.AppUserDtos
{
    public class LogInAppUserDto
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
