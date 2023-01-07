using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalconDomain.Entities
{
    public class Venda : BaseEntity
    {
        public Decimal Valor { get; set; } = 0;

        //public IEnumerable<Produto> Produtos { get; set; } = Enumerable.Empty<Produto>();
        public DateTime Data { get; set; } = DateTime.MinValue;
        public int VendedorId { get; set; } = 0;
        
    }
}
