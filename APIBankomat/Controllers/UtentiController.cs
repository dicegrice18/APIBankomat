using APIBankomat.Dtos;
using APIBankomat.DB;
using APIBankomat.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIBankomat.Controllers
{
    [ApiController]
    [Route("api/Utenti")]
    public class UtentiController : ControllerBase
    {
        private readonly IDBRepository _RepoDB;
        private readonly IMapper _mapper;

        public UtentiController(IDBRepository repoDB, IMapper mapper)
        {
            _RepoDB = repoDB;
            _mapper = mapper;
        }

        #region UTENTI

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Utente>>> GetUtentiAsync()
        {
            var utenti = await _RepoDB.GetUtentiAsync();
            var utentiToReturn = _mapper.Map<IEnumerable<Utente>>(utenti);
            return Ok(utentiToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Utenti>> GetUtentiByIdAsync(int id)
        {
            try
            {
                var Utenti = await _RepoDB.GetUtentiByIdAsync(id);
                var UtentiToReturn = _mapper.Map<Utente>(Utenti);
                return Ok(UtentiToReturn);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error deleting the user: {ex.Message}");
            }                      
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBloccatoAsync(long id, [FromBody] bool bloccato)
        {
            await _RepoDB.UpdateUtenteAsync(id, bloccato);

            return Ok(new { message = "User modified successfully." });
        }

        [HttpPut("password/{id}")]
        public async Task<IActionResult> UpdateNewPasswordAsync(int id, string password)
        {
            // Recupera lo stato dell'utente dal tuo repository o database
            var user = await _RepoDB.GetUtentiByIdAsync(id);

            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }


            await _RepoDB.UpdatePasswordAsync(id, password);

            return Ok(new { message = "Password updated successfully." });
        }


        [HttpPost]
        public async Task<IActionResult> AddUtenteAsync([FromBody] UtentePost utente)
        {
            if (ModelState.IsValid)
            {
                var ris = await _RepoDB.AddUtenteAsync(utente);
                
                return Ok(new { message = "User added successfully with ID: " + ris }); 
            }
            return BadRequest(new { error = ModelState });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUtenteAsync(int id)
        {
            try
            {
                await _RepoDB.DeleteUtenteAsync(id);

                // Restituisci un oggetto JSON vuoto con uno stato di successo
                return Ok(new { message = "User deleted successfully." });
            }
            catch (Exception ex)
            {
                return NotFound(new { error = $"Error deleting the user: {ex.Message}" });
            }
        }

        #endregion

    }




}
