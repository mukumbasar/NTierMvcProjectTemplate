using MUK.NTierMvcProjectTemplate.Entities.Abstract;
using MUK.NTierMvcProjectTemplate.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUK.NTierMvcProjectTemplate.Entities.Concretes
{
    public class Thing : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AppUserId { get; set; } = null!;
        public AppUser AppUser { get; set; } = null!;
    }
}
