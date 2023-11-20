namespace MUK.NTierMvcProjectTemplate.Web.Models
{
    public class MakaleViewModel
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string İcerik { get; set; }
        public int OkunmaSayisi { get; set; }
        public int OkumaSuresi { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
        public int KonuId { get; set; }
    }
}
