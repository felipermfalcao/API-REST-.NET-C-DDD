using FalconDomain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalconDomain.Interfaces
{
    public interface IService<D> where D : BaseDTO
    {
        Task<IEnumerable<D>> GetAll();
        Task<D> GetById(int id);
        Task Post(D obj);

        Task Put(D obj);

        Task Delete(int id);
    }
}
