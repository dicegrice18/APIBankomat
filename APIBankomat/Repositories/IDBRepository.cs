using APIBankomat.DB;
using APIBankomat.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace APIBankomat.Repositories
{
    public interface IDBRepository
    {
        #region UTENTI
        Task<IEnumerable<Utenti>> GetUtentiAsync();
        Task<Utenti?> GetUtentiByIdAsync(int id);
        Task UpdateUtenteAsync(long id, bool bloccato);

        Task UpdatePasswordAsync(long id, string password);
        Task<long> AddUtenteAsync(UtentePost usr);
        Task DeleteUtenteAsync(int id);

        #endregion


        #region BANCHE
        //Task<IEnumerable<Banca>> GetBancheWithFunzionalitaAsync();

        #endregion

    }
}
