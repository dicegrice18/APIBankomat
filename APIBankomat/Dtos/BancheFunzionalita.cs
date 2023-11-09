using APIBankomat.DB;

namespace APIBankomat.Dtos
{
    public class BancheFunzionalita
    {
        public virtual Banche Banche { get; set; }

        public virtual Funzionalita Funzionalita { get; set; }

        public virtual Funzionalitum IdFunzionalitaNavigation { get; set; }
    }
}
