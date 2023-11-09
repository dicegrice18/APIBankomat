using APIBankomat.DB;

namespace APIBankomat.Dtos
{
    public class Banca
    {
        public long Id { get; set; }

        public string Nome { get; set; }

        public virtual ICollection<Funzionalita> BancheFunzionalita { get; set; } 
    }
}
