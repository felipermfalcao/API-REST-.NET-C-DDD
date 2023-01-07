using FalconDomain.DTO;
using FalconDomain.Interfaces;
using FalconServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace FalconAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedoresController : ControllerBase
    {
        private readonly IServiceVendedor _vendedoresService;

        public VendedoresController(IServiceVendedor vendedoresService)
        {
            _vendedoresService = vendedoresService;
        }

        [HttpGet]
        public async Task<IEnumerable<Vendedor>> Get()
        {
            return await _vendedoresService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Vendedor> Get(int id)
        {
            return await _vendedoresService.GetById(id);
        }

        [HttpPost]
        public async Task Post(Vendedor vendedor)
        {
            await _vendedoresService.Post(vendedor);
        }

        [HttpPut("{id}")]
        public async Task Put(Vendedor vendedor)
        {
            await _vendedoresService.Put(vendedor);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _vendedoresService.Delete(id);
        }

        [HttpGet("nome/{name}")]
        public async Task<IEnumerable<Vendedor>> Get(string name)
        {
            return await _vendedoresService.GetByName(name);
        }
    }
}
