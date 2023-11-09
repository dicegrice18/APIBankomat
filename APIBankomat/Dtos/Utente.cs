namespace APIBankomat.Dtos
{
    public class Utente
    {
        public long Id { get; set; }
        public long IdBanca { get; set; }
        public string NomeUtente { get; set; }
        public string Password { get; set; }
        public bool Bloccato { get; set; }
    }
}
