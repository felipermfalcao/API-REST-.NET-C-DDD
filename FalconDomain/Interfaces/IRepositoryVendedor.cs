using FalconDomain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalconDomain.Interfaces
{
    public interface IRepositoryVendedor : IRepository<Vendedor>
    {
        Task<IEnumerable<Vendedor>> SelectByName(string Name);
    }
}
