using APIBankomat.DB;
using APIBankomat.Dtos;
using APIBankomat.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIBankomat.Controllers
{

    [ApiController]
    [Route("api/BancheFunzionalita")]
    public class BancheFunzionalitaController : ControllerBase
    {
        private readonly IDBRepository _RepoDB;
        private readonly IMapper _mapper;
        public BancheFunzionalitaController(IDBRepository repoDB, IMapper mapper)
        {
            _RepoDB = repoDB;
            _mapper = mapper;
        }


        [HttpGet("{idBanca}")]
        public async Task<ActionResult<Funzionalita>> GetBancheFunzionalitaByBancaByIdAsync(int idBanca)
        {
            var bancheFunzionalita = await _RepoDB.GetBancheFunzionalitaByBancaByIdAsync(idBanca);

            return Ok(bancheFunzionalita);
        }
    }
}
