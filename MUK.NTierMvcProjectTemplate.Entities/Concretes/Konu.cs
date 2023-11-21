using MUK.NTierMvcProjectTemplate.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUK.NTierMvcProjectTemplate.Entities.Concretes
{
    public class Konu : IEntity
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public List<Makale> Makaleler {  get; set; }
    }
}
