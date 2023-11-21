using MUK.NTierMvcProjectTemplate.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUK.NTierMvcProjectTemplate.Dtos.Concrete
{
    public class MakaleDto : IDto
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string İcerik { get; set; }
        public int OkunmaSayisi { get; set; }
        public int OkumaSuresi { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }

        public int KonuId { get; set; }

        public string AppUserId { get; set; }
    }
}
