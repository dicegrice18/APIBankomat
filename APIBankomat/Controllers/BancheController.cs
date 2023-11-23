using APIBankomat.DB;
using APIBankomat.Dtos;
using APIBankomat.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIBankomat.Controllers
{
    [ApiController]
    [Route("api/Banche")]
    public class BancheController : ControllerBase
    {
        private readonly IDBRepository _RepoDB;
        private readonly IMapper _mapper;

        public BancheController(IDBRepository repoDB, IMapper mapper)
        {
            _RepoDB = repoDB;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Banche>>> GetClientisAsync()
        {
            IEnumerable<Banche> banche = await _RepoDB.GetBancheAsync();

            return Ok(banche);
        }
    }
}
