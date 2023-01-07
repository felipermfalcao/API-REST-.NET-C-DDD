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
    public class VendaService : BaseService<Venda>, IServiceVenda
    {
        private readonly IRepositoryVenda _vendaRepository;

        public VendaService(IRepositoryVenda vendaRepository) : base(vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        public async Task<IEnumerable<Venda>> GetByInterval(DateTime minDate, DateTime maxDate)
        {
            return await _vendaRepository.SelectByInterval(minDate, maxDate);
        }
    }
}
