using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MUK.NTierMvcProjectTemplate.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUK.NTierMvcProjectTemplate.DAL.EntityConfigurations
{
    public class KonuConfiguration : IEntityTypeConfiguration<Konu>
    {
        public void Configure(EntityTypeBuilder<Konu> builder)
        {
            builder.HasMany(x => x.Makaleler)
                .WithOne(m => m.Konu)
                .HasForeignKey(m => m.KonuId);
        }
    }
}
