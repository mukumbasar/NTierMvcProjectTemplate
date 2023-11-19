using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MUK.NTierMvcProjectTemplate.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUK.NTierMvcProjectTemplate.DAL.EntityConfigurations
{
	public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
	{
		public void Configure(EntityTypeBuilder<AppUser> builder)
		{
			builder.Property(x => x.Name).HasMaxLength(30).IsRequired();
			builder.Property(x => x.Surname).HasMaxLength(30).IsRequired();

			builder.HasMany(x => x.Things)
				.WithOne(t => t.AppUser)
				.HasForeignKey(t => t.AppUserId);
		}
	}
}
