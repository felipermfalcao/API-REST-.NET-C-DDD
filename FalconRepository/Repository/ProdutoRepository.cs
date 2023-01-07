using FalconDomain.Entities;
using FalconDomain.Interfaces;
using FalconRepository.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalconRepository.Repository
{
    public class ProdutoRepository : BaseRepository<Produto, FalconDomain.DTO.Produto>, IRepositoryProduto
    {
        private readonly DBContext _context;
        public ProdutoRepository(DBContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<FalconDomain.DTO.Produto>> SelectByName(string Name)
        {
            var entities = _context.Produtos.Where(p => p.Nome.Contains(Name)).AsEnumerable();
            return JsonConvert.DeserializeObject<IEnumerable<FalconDomain.DTO.Produto>>(JsonConvert.SerializeObject(entities));
        }
    }
}
