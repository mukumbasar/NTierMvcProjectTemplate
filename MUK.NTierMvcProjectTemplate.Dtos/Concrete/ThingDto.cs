using MUK.NTierMvcProjectTemplate.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUK.NTierMvcProjectTemplate.Dtos.Concrete
{
    public class ThingDto : IDto
    {
        public string Name { get; set; }
        public string AppUserId { get; set; } = null!;
    }
}
