using FalconDomain.DTO;
using FalconDomain.Interfaces;
using FalconServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace FalconAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly IServiceVenda _VendasService;

        public VendasController(IServiceVenda VendasService)
        {
            _VendasService = VendasService;
        }

        [HttpGet]
        public async Task<IEnumerable<Venda>> Get()
        {
            return await _VendasService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Venda> Get(int id)
        {
            return await _VendasService.GetById(id);
        }

        [HttpPost]
        public async Task Post(Venda Venda)
        {
            await _VendasService.Post(Venda);
        }

        [HttpPut("{id}")]
        public async Task Put(Venda Venda)
        {
            await _VendasService.Put(Venda);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _VendasService.Delete(id);
        }

        [HttpGet("Data/{minDate}&{maxDate}")]
        public async Task<IEnumerable<Venda>> Get(DateTime minDate, DateTime maxDate)
        {
            return await _VendasService.GetByInterval(minDate, maxDate);
        }
    }
}
