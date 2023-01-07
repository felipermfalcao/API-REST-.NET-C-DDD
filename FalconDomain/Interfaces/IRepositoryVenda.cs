using FalconDomain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalconDomain.Interfaces
{
    public interface IRepositoryVenda : IRepository<Venda>
    {
        Task<IEnumerable<Venda>> SelectByInterval(DateTime minDate, DateTime maxDate);
    }
}
