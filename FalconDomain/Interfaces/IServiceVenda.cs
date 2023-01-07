using FalconDomain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalconDomain.Interfaces
{
    public interface IServiceVenda : IService<Venda>
    {
        Task<IEnumerable<Venda>> GetByInterval(DateTime minDate, DateTime maxDate);
    }
}
