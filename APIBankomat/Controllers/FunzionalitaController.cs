using APIBankomat.DB;
using APIBankomat.Dtos;
using APIBankomat.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIBankomat.Controllers
{
    [ApiController]
    [Route("api/Funzionalita")]
    public class FunzionalitaController : ControllerBase
    {
        private readonly IDBRepository _RepoDB;
        private readonly IMapper _mapper;
        public FunzionalitaController(IDBRepository repoDB, IMapper mapper)
        {
            _RepoDB = repoDB;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funzionalita>>> GetFunzionalitaAsync()
        {
            var funzionalita = await _RepoDB.GetFunzionalitaAsync();
            var funcToReturn = _mapper.Map<IEnumerable<Funzionalita>>(funzionalita);

            return Ok(funcToReturn);
        }

    }
}
