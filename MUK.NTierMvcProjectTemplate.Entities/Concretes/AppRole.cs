using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MUK.NTierMvcProjectTemplate.Entities.Abstract;

namespace MUK.NTierMvcProjectTemplate.Entities.Concretes
{
	public class AppRole : IdentityRole, IEntity
	{

	}
}
