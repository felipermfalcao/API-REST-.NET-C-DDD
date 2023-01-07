using FalconDomain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalconDomain.Interfaces
{
    public interface IRepository<D> where D : BaseDTO
    {
        Task<IEnumerable<D>> SelectAll();

        Task<D> SelectById(int id);

        Task Insert(D obj);

        Task Update(D obj);

        Task Del(int id);
    }
}
