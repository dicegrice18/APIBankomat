using System;
using System.Collections.Generic;

namespace APIBankomat.DB;

public partial class Utenti
{
    public long Id { get; set; }

    public long IdBanca { get; set; }

    public string NomeUtente { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool Bloccato { get; set; }

    public virtual ICollection<ContiCorrente> ContiCorrentes { get; set; } = new List<ContiCorrente>();

    public virtual Banche IdBancaNavigation { get; set; } = null!;
}
