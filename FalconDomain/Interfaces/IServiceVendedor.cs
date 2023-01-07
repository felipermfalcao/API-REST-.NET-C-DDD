using FalconDomain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalconDomain.Interfaces
{
    public interface IServiceVendedor : IService<Vendedor>
    {
        Task<IEnumerable<Vendedor>> GetByName(string name);
    }
}
