using FalconDomain.DTO;
using FalconDomain.Entities;
using FalconDomain.Interfaces;
using FalconRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalconServices.Services
{
    public class BaseService<T> : IService<T> where T : BaseDTO
    {
        private readonly IRepository<T> _repository;

        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _repository.SelectAll();
        }

        public async Task<T> GetById(int id)
        {
            return await _repository.SelectById(id);
        }

        public async Task Post(T obj)
        {
            await _repository.Insert(obj);
        }

        public async Task Put(T obj)
        {
            await _repository.Update(obj);
        }

        public async Task Delete(int id)
        {
            await _repository.Del(id);
        }
    }
}
