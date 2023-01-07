using FalconDomain.DTO;
using FalconDomain.Entities;
using FalconDomain.Interfaces;
using FalconRepository.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendedor = FalconDomain.Entities.Vendedor;

namespace FalconRepository.Repository
{
    public class VendedorRepository : BaseRepository<Vendedor, FalconDomain.DTO.Vendedor>, IRepositoryVendedor
    {
        private readonly DBContext _context;
        public VendedorRepository(DBContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<FalconDomain.DTO.Vendedor>> SelectByName(string Name)
        {
            var entities = _context.Vendedores.Where(v => v.Nome.Contains(Name)).AsEnumerable();
            return JsonConvert.DeserializeObject<IEnumerable<FalconDomain.DTO.Vendedor>>(JsonConvert.SerializeObject(entities));
        }
    }
}
