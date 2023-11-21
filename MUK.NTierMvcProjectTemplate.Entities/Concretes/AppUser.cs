using Microsoft.AspNetCore.Identity;
using MUK.NTierMvcProjectTemplate.Entities.Abstract;
using MUK.NTierMvcProjectTemplate.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUK.NTierMvcProjectTemplate.Entities.Concretes
{
	public class AppUser : IdentityUser, IEntity
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Description { get; set; }
		public string? PhotoPath { get; set; }
		public bool IsBanned { get; set; }

		public List<Makale> Makaleler { get; set; }
	}
}
