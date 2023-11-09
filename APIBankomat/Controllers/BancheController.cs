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


        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Banca>>> GetBancheAsync()
        //{
        //    var banche = await _RepoDB.GetBancheAsync();
        //    var bancheDTOs = new List<Banca>();

        //    foreach (var banca in banche)
        //    {
        //        var bancaDTO = new Banca
        //        {
        //            Id = banca.Id,
        //            Nome = banca.Nome,
        //            BancheFunzionalita = banca.BancheFunzionalita.Select(bf => bf.IdFunzionalitaNavigation.Nome).ToList()
        //        };

        //        bancheDTOs.Add(bancaDTO);
        //    }

        //    return Ok(bancheDTOs);
        //}
    }
}
