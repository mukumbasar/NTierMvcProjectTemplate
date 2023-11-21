using MUK.NTierMvcProjectTemplate.Entities.Abstract;
using MUK.NTierMvcProjectTemplate.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUK.NTierMvcProjectTemplate.Entities.Concretes
{
    public class Makale : IEntity
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string İcerik { get; set; }
        public int OkunmaSayisi { get; set; }
        public int OkumaSuresi { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }

        public string AppUserId { get; set; } = null!;
        public AppUser AppUser { get; set; } = null!;

        public int KonuId { get; set; }
        public Konu Konu { get; set; } = null!;
    }
}
