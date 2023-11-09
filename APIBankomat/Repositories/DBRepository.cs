using APIBankomat.DB;
using APIBankomat.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIBankomat.Repositories
{
    public class DBRepository : IDBRepository
    {

        private BankomatContext _ctx;
        private readonly IMapper _mapper;
        public DBRepository(BankomatContext ctx, IMapper mapper)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
            _mapper = mapper;
        }

        public async Task<bool> SaveChanges()
        {
            return (await _ctx.SaveChangesAsync() >= 0);
        }


        #region UTENTI
        public async Task<IEnumerable<Utenti>> GetUtentiAsync()
        {
            return await _ctx.Utentis.OrderBy(c => c.Id).ToListAsync();
        }

        public async Task<Utenti?> GetUtentiByIdAsync(int id)
        {
            return await _ctx.Utentis
                .Where(c => c.Id == id)
                    .FirstOrDefaultAsync();
        }

        public async Task UpdateUtenteAsync(long id, bool bloccato)
        {
            var utente = await _ctx.Utentis.FirstOrDefaultAsync(u => u.Id == id);

            if (utente != null)
            {
                utente.Bloccato = bloccato;
                await _ctx.SaveChangesAsync();
            }
        }

        public async Task UpdatePasswordAsync(long id, string password)
        {
            var utente = await _ctx.Utentis.FindAsync(id);

            if (utente != null)
            {
                utente.Password = password;
                await _ctx.SaveChangesAsync();
            }
        }

        public async Task<long> AddUtenteAsync(UtentePost usr)
        {
            var newUsr = _mapper.Map<Utenti>(usr);
            var contocorrente = new ContiCorrente() 
            { 
                IdUtente = newUsr.Id, 
                Saldo = 0, 
                DataUltimaOperazione = DateTime.Today, 
                DataUltimoVersamento = DateTime.Today, 
            };

            newUsr.ContiCorrentes.Add(contocorrente);
            newUsr.Bloccato = false;
            _ctx.Utentis.Add(newUsr);
            await _ctx.SaveChangesAsync();
            return newUsr.Id;
        }

        public async Task DeleteUtenteAsync(int id)
        {
            var User = await _ctx.Utentis.FirstOrDefaultAsync(drink => drink.Id == id);

            if (User != null)
            {
                _ctx.Utentis.Remove(User); // Elimina l'entità dal contesto
                await _ctx.SaveChangesAsync(); // Salva le modifiche nel database
            }
            else
            {
                throw new Exception("User not found");
            }
        }
        #endregion

        /*#region BANCHE
        public async Task<Banche?> UpdateUtenteAsync(string username, bool bloccato)
        {
            var utente = await _ctx.Banches
                .FirstOrDefaultAsync(u => u.NomeUtente == username);

            if (utente != null)
            {
                utente.Bloccato = bloccato;
                await _context.SaveChangesAsync();
            }

            return utente;
        }
        

        #endregion
        */


    }
}
