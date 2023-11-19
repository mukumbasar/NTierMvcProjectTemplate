using Microsoft.AspNetCore.Identity;
using MUK.NTierMvcProjectTemplate.Entities.Abstract;
using MUK.NTierMvcProjectTemplate.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUK.NTierMvcProjectTemplate.Entities.Concrete
{
	public class AppUser : IdentityUser, IEntity
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public bool IsBanned { get; set; }

		public List<Thing> Things { get; set; }
	}
}
