using FalconDomain.DTO;
using FalconDomain.Interfaces;
using FalconRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalconServices.Services
{
    public class ProdutoService : BaseService<Produto>, IServiceProduto
    {
        private readonly IRepositoryProduto _repositoryProduto;

        public ProdutoService(IRepositoryProduto repositoryProduto) : base(repositoryProduto)
        {
            _repositoryProduto = repositoryProduto;
        }

        public async Task<IEnumerable<Produto>> GetByName(string name)
        {
            return await _repositoryProduto.SelectByName(name);
        }
    }
}
