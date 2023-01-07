using FalconDomain.DTO;
using FalconDomain.Interfaces;
using FalconRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalconServices.Services
{
    public class VendedorService : BaseService<Vendedor>, IServiceVendedor
    {
        private readonly IRepositoryVendedor _vendedorRepository;

        public VendedorService(IRepositoryVendedor vendedorRepository) : base(vendedorRepository)
        {
            _vendedorRepository = vendedorRepository;
        }

        public async Task<IEnumerable<Vendedor>> GetByName(string name)
        {
            return await _vendedorRepository.SelectByName(name);
        }
    }
}
