using FalconDomain.Entities;
using FalconRepository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Threading.Tasks;
using FalconDomain.Interfaces;

namespace FalconRepository.Repository
{
    public class VendaRepository : BaseRepository<Venda, FalconDomain.DTO.Venda>, IRepositoryVenda
    {
        private readonly DBContext _context;
        public VendaRepository(DBContext context) : base(context)
        {
            _context = context;
        }

        //public async Task<IEnumerable<Venda>> SelectByInterval(DateTime minDate, DateTime maxDate)
        //{
        //    var result = _context.Vendas.Where(obj => obj.Id > 0);
        //    return result.Where(v => v.Data.Date >= minDate.Date && v.Data.Date <= maxDate.Date).OrderByDescending(v => v.Data);
        //}

        public async Task<IEnumerable<FalconDomain.DTO.Venda>> SelectByInterval(DateTime minDate, DateTime maxDate)
        {
            var result = _context.Vendas.Where(v => v.Data.Date >= minDate.Date && v.Data.Date <= maxDate.Date)
                                        .OrderByDescending(v => v.Data)
                                        .ToArray();
            var resultJson = JsonConvert.SerializeObject(result);
            return JsonConvert.DeserializeObject<IEnumerable<FalconDomain.DTO.Venda>>(resultJson);
        }
    }
}
