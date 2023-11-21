using MUK.NTierMvcProjectTemplate.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUK.NTierMvcProjectTemplate.Dtos.Concrete
{
    public class KonuDto : IDto
    {
        public int Id { get; set; }
        public string Ad { get; set; }
    }
}
