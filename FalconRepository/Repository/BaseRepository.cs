using FalconDomain.DTO;
using FalconDomain.Entities;
using FalconDomain.Interfaces;
using FalconRepository.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalconRepository.Repository
{
    public class BaseRepository<T,D> : IRepository<D>
        where T : BaseEntity
        where D : BaseDTO
    {
        private readonly DBContext _context;
        public BaseRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<D>> SelectAll()
        {
            var entity = this._context.Set<T>();
            return JsonConvert.DeserializeObject<IEnumerable<D>>(JsonConvert.SerializeObject(entity));
        }

        public async Task<D> SelectById(int id)
        {
            //return await _context.Set<D>().FindAsync(id);
            var entity = await this._context.Set<T>().FindAsync(id);
            return JsonConvert.DeserializeObject<D>(JsonConvert.SerializeObject(entity));
        }

        public async Task Insert(D obj)
        {
            await _context.Set<D>().AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Update(D obj)
        {
            T _obj = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj));
            _context.Set<T>().Update(_obj);
            await _context.SaveChangesAsync();
        }

        public async Task Del(int id)
        {
           var obj = await _context.Set<D>().FindAsync(id);
           _context.Set<D>().Remove(obj);
           await _context.SaveChangesAsync();
        }
    }
}
